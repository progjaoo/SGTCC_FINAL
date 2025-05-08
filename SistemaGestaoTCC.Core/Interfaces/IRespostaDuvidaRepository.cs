using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IRespostaDuvidaRepository
    {
        Task<List<RespostaDuvida>> GetAllAsync();
        Task<RespostaDuvida?> GetByIdAsync(int id);
        Task<List<RespostaDuvida>> GetByDuvidaIdAsync(int idDuvida);
        Task<List<RespostaDuvida>> GetByUsuarioIdAsync(int idUsuario);
        Task AddAsync(RespostaDuvida resposta);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
