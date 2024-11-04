using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Projeto>> GetAllAsync();
        Task<List<Projeto>> GetAllPendingAsync();
        Task<List<Projeto>> GetAllByUserAsync(int id);
        Task<List<Projeto>> GetAllActiveByUserAsync(int id);
        Task<Projeto> GetById(int id);
        Task<Projeto> GetDetailsByIdAsync(int id);
        Task AddASync(Projeto projeto);
        Task StartAsync(Projeto projeto);
        Task Finalizar(int id);
        Task TornarPublico(int id);
        Task SaveChangesAsync();
    }
}