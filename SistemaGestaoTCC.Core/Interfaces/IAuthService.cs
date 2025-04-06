namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
        string ComputeSha256Hash(string password);

        Task<bool> SendActivationEmailAsync(int userId, string userEmail);
        Task<bool> ActivateAccountAsync(string token);

        Task<bool> SendPasswordResetEmailAsync(string userEmail);
        Task<bool> ResetPasswordAsync(string token, string newPassword);
    }
}