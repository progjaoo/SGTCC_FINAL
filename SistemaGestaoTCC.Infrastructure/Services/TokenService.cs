using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Models;
using SistemaGestaoTCC.Infrastructure;

namespace SistemaGestaoTCC.Infrastructure.Services
{
    public class TokenService
    {
        private readonly SGTCCContext _context;

        public TokenService(SGTCCContext context)
        {
            _context = context;
        }

        // Método para gerar um token seguro
        public async Task<string> GenerateTokenAsync(int userId, string type, int expirationMinutes = 30)
        {
            // Gerando um token aleatório
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

            // Criando um novo registro no banco
            var userToken = new UserToken
            {
                UserId = userId,
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(expirationMinutes),
                Type = type
            };

            _context.UserTokens.Add(userToken);
            await _context.SaveChangesAsync();

            return token;
        }

        // Método para validar o token recebido
        public async Task<bool> ValidateTokenAsync(int userId, string token, string type)
        {
            var userToken = await _context.UserTokens
                .FirstOrDefaultAsync(ut => ut.UserId == userId && ut.Token == token && ut.Type == type);

            if (userToken == null || userToken.Expiration < DateTime.UtcNow)
            {
                return false; // Token inválido ou expirado
            }

            // Se for válido, removemos o token para evitar reuso
            _context.UserTokens.Remove(userToken);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
