using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
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
