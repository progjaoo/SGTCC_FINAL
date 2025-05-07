using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class PasswordResetTokenRepository : IPasswordResetTokenRepository
    {
        private readonly SGTCCContext _context;

        public PasswordResetTokenRepository(SGTCCContext context)
        {
            _context = context;
        }

        public async Task<PasswordResetToken> GenerateTokenAsync(int userId)
        {
            var token = new PasswordResetToken
            {
                UserId = userId,
                Token = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.Now.AddHours(1)
            };

            _context.PasswordResetTokens.Add(token);
            await _context.SaveChangesAsync();
            return token;
        }

        public async Task<PasswordResetToken> GetByTokenAsync(string token)
        {
            return await _context.PasswordResetTokens
                .FirstOrDefaultAsync(t => t.Token == token && t.ExpirationDate > DateTime.Now);
        }

        public async Task DeleteTokenAsync(string token)
        {
            var tokenEntry = await _context.PasswordResetTokens.FirstOrDefaultAsync(t => t.Token == token);
            if (tokenEntry != null)
            {
                _context.PasswordResetTokens.Remove(tokenEntry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
