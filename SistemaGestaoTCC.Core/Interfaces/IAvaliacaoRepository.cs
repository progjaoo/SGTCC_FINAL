using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<ProjetoAvaliacaoPublica> GetById(int id);
        Task<List<ProjetoAvaliacaoPublica>> GetAvaliacoesByUsuarioAsync(int idUsuario);
        Task<List<ProjetoAvaliacaoPublica>> GetAvaliacoesByProjectAsync(int idProjeto);
        Task<ProjetoAvaliacaoPublica> GetAvaliacoesByProjectAndUserAsync(int idProjeto, int idUsuario);
        Task AddASync(ProjetoAvaliacaoPublica avaliacao);
        Task Remove(ProjetoAvaliacaoPublica avaliacao);
        Task SaveChangesAsync();
    }
}
