using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IAtividadeComentarioRepository
    {
        Task<List<AtividadeComentario>> GetAllAsync();
        Task<AtividadeComentario> GetById(int id);
        Task AddASync(AtividadeComentario atividadeComentario);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
