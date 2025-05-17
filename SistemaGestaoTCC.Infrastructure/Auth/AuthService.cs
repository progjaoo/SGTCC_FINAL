using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using SistemaGestaoTCC.Infrastructure.Repositories;
using SistemaGestaoTCC.Infrastructure.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Google.Apis.Auth;



namespace SistemaGestaoTCC.Infrastructure.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IUserActivationTokenRepository _activationTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordResetTokenRepository _passwordResetTokenRepository;

        public AuthService(
            IConfiguration configuration,
            IEmailService emailService,
            IUserActivationTokenRepository activationTokenRepository,
            IUserRepository userRepository,
            IPasswordResetTokenRepository passwordResetTokenRepository)
        {
            _configuration = configuration;
            _emailService = emailService;
            _activationTokenRepository = activationTokenRepository;
            _userRepository = userRepository;
            _passwordResetTokenRepository = passwordResetTokenRepository;
        }

        public string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] bytes = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // x2 faz com que seja convertido em representação hexadecimal
                }

                return builder.ToString();
            }
        }

        public string GenerateJwtToken(string email, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("userName", email),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials,
                claims: claims);

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
        public async Task<bool> SendActivationEmailAsync(int userId, string userEmail)
        {
            var token = await _activationTokenRepository.GenerateTokenAsync(userId);
            if (token == null)
            {
                Console.WriteLine("Erro: Falha ao gerar token.");
                throw new Exception("Erro: Falha ao gerar token.");
            }

            string subject = "Ative sua conta - Código de verificação";

            string body = $@"
            <html>
            <body style='font-family: Arial, sans-serif; background-color: #f6f9fc; margin: 0; padding: 20px;'>
                <div style='max-width: 600px; margin: auto; background-color: #ffffff; padding: 30px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.05);'>
                <h2 style='color: #2c3e50;'>Olá!</h2>
                <p style='font-size: 16px; color: #333333;'>
                    Recebemos uma solicitação para ativar sua conta. Use o código abaixo para concluir o processo de ativação ou clique no link:
                </p>
                <div style='font-size: 26px; font-weight: bold; color: #1a73e8; background-color: #eef3fb; padding: 15px; text-align: center; border-radius: 6px; margin: 20px 0;'>
                    http://localhost:5173/ativacao?ativarConta={token.Token} ou copie e cole o código no App: {token.Token}
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

            await _emailService.SendEmailAsync(userEmail, subject, body);

            return true;
        }

        public async Task<Usuario> ActivateAccountAsync(string token)
        {
            var tokenObj = await _activationTokenRepository.GetTokenAsync(token);
            if (tokenObj == null || tokenObj.ExpirationDate < DateTime.Now)
                return null; // Token inválido ou expirado

            var user = await _userRepository.GetByIdAsync(tokenObj.UserId);
            if (user == null)
                return null;

            user.EmailVerificado = EmailVerificadoEnum.Sim;
            user.EditadoEm = DateTime.Now;
            await _userRepository.UpdateAsync(user);

            await _activationTokenRepository.RemoveTokenAsync(token);
            return user;
        }

        public async Task<bool> SendPasswordResetEmailAsync(string userEmail)
        {
            var user = await _userRepository.GetUserByEmailAsync(userEmail);
            if (user == null) return false;

            var token = await _passwordResetTokenRepository.GenerateTokenAsync(user.Id);

            var subject = "Redefinir Senha";
            var body = $"{token.Token}";

            return await _emailService.SendEmailAsync(userEmail, subject, body);
        }

        public async Task<Usuario> ResetPasswordAsync(string token, string newPassword)
        {
            var tokenData = await _passwordResetTokenRepository.GetByTokenAsync(token);
            if (tokenData == null) return null;

            var user = await _userRepository.GetByIdAsync(tokenData.UserId);
            if (user == null) return null;

            user.Senha = ComputeSha256Hash(newPassword); // aplica criptografia
            await _userRepository.UpdateAsync(user);
            await _passwordResetTokenRepository.DeleteTokenAsync(token);

            return user;
        }

        public async Task<string> GoogleLoginAsync(string idToken)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);

            // Verifica se o usuário já existe
            var existingUser = await _userRepository.GetUserByEmailAsync(payload.Email);
            if (existingUser == null)
            {
                // Cria novo usuário com base no Google
                var novoUsuario = new Usuario(
                    idCurso: 1, // ou outro curso padrão
                    nome: payload.Name,
                    email: payload.Email,
                    senha: "", // sem senha já que é login social
                    papel: (PapelEnum)1 // ou outro papel padrão
                );
                await _userRepository.UpdateAsync(novoUsuario);
                existingUser = novoUsuario;
            }

            // Gera token JWT
            var token = GenerateJwtToken(existingUser.Email, existingUser.Papel.ToString());
            return token;
        }
        public async Task<(string Email, string Name)> GetGoogleUserInfoAsync(string idToken)
        {
            try
            {
                // Validar o token do Google e obter as informações do usuário
                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);

                // Retornar o e-mail e o nome do usuário
                return (payload.Email, payload.Name);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao validar o token do Google: " + ex.Message);
            }
        }
    }
}