using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Core.Interfaces
{
    public interface IUsuarioProjetoRepository
    {
        Task<UsuarioProjeto> GetById(int id);
        Task<List<UsuarioProjeto>> GetAllAsync();
        Task<List<UsuarioProjeto>> GetAllByUserId(int id);
        Task<List<Usuario>> GetAllByProjectId(int id);
        Task AddASync(UsuarioProjeto usuarioProjeto);
        Task SaveChangesAsync();
        Task DeleteUserProj(int id);
    }
}