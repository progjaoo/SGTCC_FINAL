using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Infrastructure;

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
    public async Task<bool> SendActivationEmailAsync(int userId, string userEmail)
{
    try
    {
        var token = await _userActivationTokenRepository.GenerateTokenAsync(userId);
        if (token == null)
        {
            Console.WriteLine("Erro: Falha ao gerar token.");
            return false;
        }

        string subject = "Ativação de Conta";
        string body = $"Seu código de ativação é: {token.Token}";

        bool emailSent = await _emailService.SendEmailAsync(userEmail, subject, body);
        if (!emailSent)
        {
            Console.WriteLine("Erro: Falha ao enviar o e-mail.");
            return false;
        }

        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro no envio do e-mail: {ex.Message}");
        return false;
    }
}


    [HttpPost("activate-account")]
    public async Task<IActionResult> ActivateAccount([FromQuery] string token)
    {
        var result = await _authService.ActivateAccountAsync(token);
        return result ? Ok("Conta ativada com sucesso!") : BadRequest("Token inválido ou expirado.");
    }
}