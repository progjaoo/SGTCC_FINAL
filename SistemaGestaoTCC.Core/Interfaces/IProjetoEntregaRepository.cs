using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IProjetoEntregaRepository
    {
        Task<List<ProjetoEntrega>> GetAllAsync();
        Task<ProjetoEntrega> GetByIdAsync(int id);
        Task<List<ProjetoEntrega>> GetEntregasByProjetoIdAsync(int projetoId);

        Task AddAsync(ProjetoEntrega projetoEntrega);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
