using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IRelatorioAcompanhamentoRepository
    {
        Task<List<RelatorioAcompanhamento>> GetAllAsync();
        Task<RelatorioAcompanhamento> GetById(int id);
        Task<List<RelatorioAcompanhamento>> GetRelatorioByProjectAsync(int idProjeto);
        Task<List<RelatorioAcompanhamento>> GetRelatorioByUserAsync(int idUsuario);
        Task AddAsync(RelatorioAcompanhamento relatorio);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
