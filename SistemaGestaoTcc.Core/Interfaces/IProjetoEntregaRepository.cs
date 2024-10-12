using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IProjetoEntregaRepository
    {
        Task<List<ProjetoEntrega>> GetAllAsync();
        Task<ProjetoEntrega> GetByIdAsync(int id);
        Task AddAsync(ProjetoEntrega projetoEntrega);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
