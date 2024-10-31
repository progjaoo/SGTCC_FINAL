using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IProjetoArquivoRepository
    {
        Task<ProjetoArquivo> GetById(int id);
        Task<List<ProjetoArquivo>> GetAllAsync();
        Task AddASync(ProjetoArquivo projetoArquivo);
        Task SaveChangesAsync();
        Task Delete(int id);
    }
}
