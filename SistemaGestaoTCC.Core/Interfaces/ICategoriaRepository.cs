using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<Categoria> GetByIdAsync(int id);
        Task<List<Categoria>> GetAllAsync();
        Task AddAsync(Categoria categoria);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
