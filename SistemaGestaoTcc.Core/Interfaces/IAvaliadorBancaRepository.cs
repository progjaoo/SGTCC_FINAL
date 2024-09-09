using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IAvaliadorBancaRepository
    {
        Task<AvaliadorBanca> GetByIdAsync(int id);
        Task<List<AvaliadorBanca>> GetByBancaIdAsync(int bancaId);
        Task<List<AvaliadorBanca>> GetAllAsync();
        Task AddAsync(AvaliadorBanca avaliadorBanca);
        Task UpdateAsync(AvaliadorBanca avaliadorBanca);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
