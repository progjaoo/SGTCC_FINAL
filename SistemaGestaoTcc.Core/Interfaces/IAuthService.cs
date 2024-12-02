namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);
        string ComputeSha256Hash(string password);
    }
}