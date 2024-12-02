using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface ICampoDocumentoRepository
    {
        Task<List<CampoDocumentoAvaliacaoAluno>> GetAllAsync();
        Task<CampoDocumentoAvaliacaoAluno> GetByIdAsync(int id);
        Task AddAsync(CampoDocumentoAvaliacaoAluno campoDocumentoAvaliacaoAluno);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
