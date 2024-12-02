using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface INotasDocumentoAlunoRepository
    {
        Task<NotaDocumentoAluno> GetByIdAsync(int id);
        Task<List<NotaDocumentoAluno>> GetAllAsync();
        Task AddAsync(NotaDocumentoAluno notasDocumentoAluno);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
