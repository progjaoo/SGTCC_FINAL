using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<ProjetoAvaliacaoPublica> GetById(int id);
        Task<List<ProjetoAvaliacaoPublica>> GetAvaliacoesByUsuarioAsync(int idUsuario);
        Task AddASync(ProjetoAvaliacaoPublica avaliacao);
        Task SaveChangesAsync();
    }
}
