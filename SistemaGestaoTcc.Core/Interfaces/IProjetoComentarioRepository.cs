using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IProjetoComentarioRepository
    {
        Task<List<ProjetoComentario>> GetAllAsync();
        Task<ProjetoComentario> GetById(int id);
        Task<IEnumerable<ProjetoComentario>> GetAllCommentsByProject(int projectId);
        Task<IEnumerable<ProjetoComentario>> GetAllCommentsByUser(int userId);
        Task AddASync(ProjetoComentario comentario);
        Task DeleteComentario(int id);
        Task SaveChangesAsync();
    }
}
