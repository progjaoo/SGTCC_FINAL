using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPasswordResetTokenRepository
{
    Task<PasswordResetToken> GenerateTokenAsync(int userId);
    Task<PasswordResetToken> GetByTokenAsync(string token);
    Task DeleteTokenAsync(string token);
}
