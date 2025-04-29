using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IAnotacaoRepository
    {
        Task<List<Anotacao>> GetAllAsync();
        Task<List<Anotacao>> GetAnotacoesByTituloAsync(string titulo, int idProjeto);
        Task<Anotacao> GetById(int id);
        Task<List<Anotacao>> GetAnotacaoByIdProjectAsync(int idProjeto);
        Task<List<Anotacao>> GetAnotacaoByUserAsync(int idUsuario);
        Task AddAsync(Anotacao anotacao);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
