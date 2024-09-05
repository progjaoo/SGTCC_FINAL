using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IProjetoAtividadeRepository
    {
        Task<List<ProjetoAtividade>> GetAllAsync();
        Task<ProjetoAtividade> GetById(int id);
        Task AddASync(ProjetoAtividade atividade);
        Task DeleteAtividade(int id);
        Task SaveChangesAsync();
    }
}
