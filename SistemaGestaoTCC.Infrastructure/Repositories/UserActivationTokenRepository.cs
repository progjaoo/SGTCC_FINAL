using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using System;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class UserActivationTokenRepository : IUserActivationTokenRepository
    {
        private readonly SGTCCContext _context;

        public UserActivationTokenRepository(SGTCCContext context)
        {
            _context = context;
        }

        public async Task<UserActivationToken> GenerateTokenAsync(int userId)
        {
            var token = new UserActivationToken
            {
                UserId = userId,
                Token = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.UtcNow.AddHours(24)
            };

            await _context.UserActivationTokens.AddAsync(token);
            await _context.SaveChangesAsync();

            return token;
        }

        public async Task<UserActivationToken> GetTokenAsync(string token)
        {
            return await _context.UserActivationTokens
                .FirstOrDefaultAsync(t => t.Token == token);
        }

        public async Task RemoveTokenAsync(string token)
        {
            var tokenObj = await _context.UserActivationTokens
                .FirstOrDefaultAsync(t => t.Token == token);

            if (tokenObj != null)
            {
                _context.UserActivationTokens.Remove(tokenObj);
                await _context.SaveChangesAsync();
            }
        }
    }
}