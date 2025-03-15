using System;
using System.Threading.Tasks;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IUserActivationTokenRepository
    {
        Task<UserActivationToken> GenerateTokenAsync(int userId);
        Task<UserActivationToken> GetTokenAsync(string token);
        Task RemoveTokenAsync(string token);
    }
}