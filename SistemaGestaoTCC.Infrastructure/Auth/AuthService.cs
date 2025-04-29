using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Infrastructure.Repositories;
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

            var user = await _userRepository.GetByIdAsync(tokenObj.UserId);
            if (user == null)
                return false;

            user.EmailVerificado = EmailVerificadoEnum.Sim;
            user.EditadoEm = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            await _activationTokenRepository.RemoveTokenAsync(token);
            return true;
        }

        public async Task<bool> SendPasswordResetEmailAsync(string userEmail)
        {
            var user = await _userRepository.GetUserByEmailAsync(userEmail);
            if (user == null) return false;

            var token = await _passwordResetTokenRepository.GenerateTokenAsync(user.Id);
            var link = $"token={token.Token}";
            var body = $"{token.Token}";

            return await _emailService.SendEmailAsync(userEmail, "Redefinir Senha", body);
        }

        public async Task<bool> ResetPasswordAsync(string token, string newPassword)
        {
            var tokenData = await _passwordResetTokenRepository.GetByTokenAsync(token);
            if (tokenData == null) return false;

            var user = await _userRepository.GetByIdAsync(tokenData.UserId);
            if (user == null) return false;

            user.Senha = ComputeSha256Hash(newPassword); // aplica criptografia
            await _userRepository.UpdateAsync(user);
            await _passwordResetTokenRepository.DeleteTokenAsync(token);

            return true;
        }
    }
}