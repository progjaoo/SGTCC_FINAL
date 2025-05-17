using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IPropostaRepository
    {
        Task<Proposta> GetByIdAsync(int id);
        Task<List<Proposta>> GetPropostaByProject(int idProjeto);
        Task<List<Proposta>> GetAllAsync();
        Task AddAsync(Proposta proposta);
        Task<bool> AtualizarParecerAsync(int idProjeto, ParecerPropostaEnum novoParecer);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
