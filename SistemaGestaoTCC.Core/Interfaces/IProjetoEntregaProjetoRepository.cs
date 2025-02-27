using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IProjetoEntregaProjetoRepository
    {
        Task<ProjetoEntregaProjeto> GetById(int id);
        Task<ProjetoEntregaProjeto> GetByProjectAndEntregaAsync(int projetoId, int entregaId);
        Task<List<ProjetoEntregaProjeto>> GetAllAsync();
        Task AddAsync(ProjetoEntregaProjeto projetoEntregaProjeto);
        Task DeleteProjetoEntrega(ProjetoEntregaProjeto projetoEntregaProjeto);
        Task SaveChangesAsync();
    }
}
