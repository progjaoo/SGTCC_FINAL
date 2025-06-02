using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface ICampoDocumentoRepository
    {
        Task<List<CampoDocumentoAvaliacaoAluno>> GetAllAsync();
        Task<List<CampoDocumentoAvaliacaoAluno>> GetAllByCategoryAsync(int idCategoria);
        Task<CampoDocumentoAvaliacaoAluno> GetByIdAsync(int id);
        Task AddAsync(CampoDocumentoAvaliacaoAluno campoDocumentoAvaliacaoAluno);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
