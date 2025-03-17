using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Infrastructure.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SistemaGestaoTCC.Infrastructure.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IUserActivationTokenRepository _activationTokenRepository;

        public AuthService(
            IConfiguration configuration,
            IEmailService emailService,
            IUserActivationTokenRepository activationTokenRepository)
        {
            _configuration = configuration;
            _emailService = emailService;
            _activationTokenRepository = activationTokenRepository;
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
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials,
                claims: claims);

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
        public async Task<bool> SendActivationEmailAsync(int userId, string userEmail)
        {
            // Gerar um token de ativação
            var token = await _activationTokenRepository.GenerateTokenAsync(userId);

            // Criar o link de ativação
            var activationLink = $"https://seusite.com/ativar-conta?token={token.Token}";

            // Montar o e-mail
            var emailBody = $@"
                <h1>Ativação de Conta</h1>
                <p>Clique no link abaixo para ativar sua conta:</p>
                <a href='{activationLink}'>Ativar Conta</a>
                <p>Esse link expira em 24 horas.</p>";

            // Enviar o e-mail
            return await _emailService.SendEmailAsync(userEmail, "Ativação de Conta", emailBody);
        }

        public async Task<bool> ActivateAccountAsync(string token)
        {
            var tokenObj = await _activationTokenRepository.GetTokenAsync(token);
            if (tokenObj == null || tokenObj.ExpirationDate < DateTime.UtcNow)
                return false; // Token inválido ou expirado

            // Aqui você pode ativar a conta do usuário no banco de dados
            // Exemplo: user.IsActive = true;

            await _activationTokenRepository.RemoveTokenAsync(token);
            return true;
        }
    }
}