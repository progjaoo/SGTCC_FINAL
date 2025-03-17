using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IProjetoAtividadeRepository
    {
        Task<List<ProjetoAtividade>> GetAllAsync();
        Task<ProjetoAtividade> GetById(int id);
        Task<List<ProjetoAtividade>> GetAtividadeByProjectIdAsync(int projectId);
        Task AddASync(ProjetoAtividade atividade);
        Task DeleteAtividade(int id);
        Task FinalizarAtividade(int id);
        Task SaveChangesAsync();
    }
}
