using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IProjetoEntregaProjetoRepository
    {
        Task AddAsync(ProjetoEntregaProjeto projetoEntregaProjeto);
        Task SaveChangesAsync();
    }
}
