using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IArquivoRepository
    {
        Task<Arquivo> GetByIdAsync(int id);
        Task<List<Arquivo>> GetAllAsync();
        Task<Arquivo> AddAsync(Arquivo arquivo);
        Task UpdateAsync(Arquivo arquivo);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}