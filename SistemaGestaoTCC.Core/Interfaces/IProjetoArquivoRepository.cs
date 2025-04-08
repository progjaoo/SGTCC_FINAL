using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IProjetoArquivoRepository
    {
        Task<ProjetoArquivo> GetById(int id);
        Task<List<ProjetoArquivo>> GetAllAsync();
        Task<List<ProjetoArquivo>> GetAllByProjectIdAsync(int idProjeto);
        Task AddASync(ProjetoArquivo projetoArquivo);
        Task SaveChangesAsync();
        Task Delete(int id);
    }
}
