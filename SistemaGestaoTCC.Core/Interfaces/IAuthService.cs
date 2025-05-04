using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
        string ComputeSha256Hash(string password);

        Task<bool> SendActivationEmailAsync(int userId, string userEmail);
        Task<Usuario> ActivateAccountAsync(string token);

        Task<bool> SendPasswordResetEmailAsync(string userEmail);
        Task<Usuario> ResetPasswordAsync(string token, string newPassword);
        Task<string> GoogleLoginAsync(string idToken);
        Task<(string Email, string Name)> GetGoogleUserInfoAsync(string idToken);
    }
}