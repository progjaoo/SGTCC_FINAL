using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IBibliografiaRepository
    {
        Task<List<Bibliografia>> GetAllAsync();
        Task<Bibliografia> GetById(int id);
        Task<List<Bibliografia>> GetBibliografiasByProject(int idProjeto);
        Task AddAsync(Bibliografia bibliografia);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
