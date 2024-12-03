using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface INotaFinalAlunoRepository
    {
        Task<NotaFinalAluno> GetByIdAsync(int id);
        Task<List<NotaFinalAluno>> GetAllAsync();
        Task AddAsync(NotaFinalAluno notaFinal);
        Task UpdateAsync(NotaFinalAluno notaFinal);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
