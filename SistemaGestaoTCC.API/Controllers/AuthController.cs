using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Auth.ResetPassword;
using SistemaGestaoTCC.Application.Queries.Users.GetUserByEmail;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Infrastructure;
using System.Security.Claims;
using SistemaGestaoTCC.Core.Models;
using SistemaGestaoTCC.Core.Enums;
using System.Security.Cryptography;
using System.Text;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;
    private readonly IUserActivationTokenRepository _userActivationTokenRepository;  // Adicionei essa dependência
    private readonly IEmailService _emailService;


    public AuthController(IAuthService authService, IUserRepository userRepository, IUserActivationTokenRepository userActivationTokenRepository, IEmailService emailService)
    {
        _authService = authService;
        _userRepository = userRepository;
        _userActivationTokenRepository = userActivationTokenRepository;  // Atribuindo a dependência
        _emailService = emailService;  // Atribuindo a dependência
    }

    [HttpPost("send-activation-email")]
    public async Task<IActionResult> SendActivationEmailAsync(int userId)
    {
        var user = await _userRepository.GetById(userId);
        if (user == null)
        {
            return NotFound();
        }

        var userEmail = user.Email;
        try
        {
            var token = await _userActivationTokenRepository.GenerateTokenAsync(userId);
            if (token == null)
            {
                Console.WriteLine("Erro: Falha ao gerar token.");
                return StatusCode(500, new { message = "Falha ao gerar token." });
            }

            string subject = "Ative sua conta - Código de verificação";

            string body = $@"
            <html>
            <body style='font-family: Arial, sans-serif; background-color: #f6f9fc; margin: 0; padding: 20px;'>
                <div style='max-width: 600px; margin: auto; background-color: #ffffff; padding: 30px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.05);'>
                <h2 style='color: #2c3e50;'>Olá!</h2>
                <p style='font-size: 16px; color: #333333;'>
                    Recebemos uma solicitação para ativar sua conta. Use o código abaixo para concluir o processo de ativação:
                </p>
                <div style='font-size: 26px; font-weight: bold; color: #1a73e8; background-color: #eef3fb; padding: 15px; text-align: center; border-radius: 6px; margin: 20px 0;'>
                    {token.Token}
                </div>
                <p style='font-size: 14px; color: #555555;'>
                    Este código é válido por tempo limitado. Se você não fez esta solicitação, ignore este e-mail.
                </p>
                <hr style='margin: 30px 0; border: none; border-top: 1px solid #e0e0e0;' />
                <p style='font-size: 12px; color: #999999; text-align: center;'>
                    © {DateTime.Now.Year} SGTCC. Todos os direitos reservados.<br />
                    Este e-mail foi enviado automaticamente, por favor, não responda.
                </p>
                </div>
            </body>
            </html>";


            bool emailSent = await _emailService.SendEmailAsync(userEmail, subject, body);
            if (!emailSent)
            {
                Console.WriteLine("Erro: Falha ao enviar o e-mail.");
                return StatusCode(500, new { message = "Falha ao enviar o e-mail." });
            }

            return Ok("E-mail enviado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no envio do e-mail: {ex.Message}");
            return StatusCode(500, new { message = "Erro no envio do e-mail." });
        }
    }


    [HttpPost("activate-account")]
    public async Task<IActionResult> ActivateAccount([FromQuery] string token)
    {
        var result = await _authService.ActivateAccountAsync(token);
        if (result == null)
        {
            return BadRequest("Token inválido ou expirado.");
        }
        return Ok("Conta ativada com sucesso!");
    }

    [HttpPost("request-password-reset")]
    public async Task<IActionResult> RequestPasswordReset(string email)
    {
        var result = await _authService.SendPasswordResetEmailAsync(email);
        return result ? Ok("E-mail enviado.") : BadRequest("E-mail não encontrado.");
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand command)
    {
        var result = await _authService.ResetPasswordAsync(command.Token, command.NovaSenha);
        if (result == null)
        {
            return BadRequest("Token inválido ou expirado.");
        }
        return Ok(result.Id);
    }

    [HttpGet("google-login")]
    public IActionResult GoogleLogin()
    {
        var redirectUrl = Url.Action("GoogleResponse", "Auth");
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] string idToken)
    {
        try
        {
            Console.WriteLine($"Recebido idToken: {idToken}");

            var googleUserInfo = await _authService.GetGoogleUserInfoAsync(idToken);
            if (googleUserInfo.Email == null || googleUserInfo.Name == null)
            {
                return BadRequest(new { error = "Token inválido ou não foi possível obter informações do usuário." });
            }

            var existingUser = await _userRepository.GetUserByEmailAsync(googleUserInfo.Email);
            if (existingUser == null)
            {
                var newUser = new Usuario(
                    idCurso: 1,
                    nome: googleUserInfo.Name,
                    email: googleUserInfo.Email,
                    senha: null,
                    papel: PapelEnum.Aluno
                );

                await _userRepository.AddAsync(newUser);
                existingUser = newUser;
            }

            var jwtToken = _authService.GenerateJwtToken(existingUser.Email, existingUser.Papel.ToString());
            return Ok(new { token = jwtToken });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no GoogleLogin: {ex.InnerException?.Message ?? ex.Message}");
            return StatusCode(500, new { error = ex.InnerException?.Message ?? ex.Message });
        }
    }
    public static string GerarSenhaAleatoria(int tamanho)
    {
        const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[]{}|;:,.<>?";
        var senha = new StringBuilder();
        using (var rng = RandomNumberGenerator.Create())
        {
            var buffer = new byte[1];
            while (senha.Length < tamanho)
            {
                rng.GetBytes(buffer);
                var indice = buffer[0] % caracteresPermitidos.Length;
                senha.Append(caracteresPermitidos[indice]);
            }
        }
        return senha.ToString();
    }

    [HttpGet("google/callback")]
    public async Task<IActionResult> GoogleResponse()
    {

        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        if (!result.Succeeded)
            return BadRequest("Erro na autenticação com o Google");

        // Obter as informações do usuário a partir dos claims
        var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
        var name = result.Principal.FindFirst(ClaimTypes.Name)?.Value;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name))
            return BadRequest("Não foi possível obter as informações do usuário.");

        try
        {
            // Verificar se o usuário já existe no banco de dados
            var existingUser = await _userRepository.GetUserByEmailAsync(email);
            if (existingUser == null)
            {
                // Criar um novo usuário
                var newUser = new Usuario(
                    idCurso: 1, // Ajuste conforme necessário
                    nome: name,
                    email: email,
                    senha: GerarSenhaAleatoria(255), // Senha não é necessária para login com Google
                    papel: PapelEnum.Aluno // Ajuste o papel conforme necessário
                );

                await _userRepository.AddAsync(newUser);

                existingUser = newUser;
            }
        var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
        var name = result.Principal.FindFirst(ClaimTypes.Name)?.Value;

            // Gerar um token JWT para o usuário
            var jwtToken = _authService.GenerateJwtToken(existingUser.Email, existingUser.Papel.ToString());
            return Ok(new { token = jwtToken });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        return Ok(new { email, name });
    }
}