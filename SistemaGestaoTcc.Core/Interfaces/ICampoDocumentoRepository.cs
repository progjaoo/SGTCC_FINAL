using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
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
