using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IBancaRepository
    {
        Task<List<Banca>> GetAllAsync();
        Task<Banca> GetById(int id);
        Task AddASync(Banca banca);
        Task DeleteBanca(int id);
        Task SaveChangesAsync();
    }
}
