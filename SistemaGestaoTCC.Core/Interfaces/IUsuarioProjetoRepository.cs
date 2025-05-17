using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IUsuarioProjetoRepository
    {
        Task<UsuarioProjeto> GetById(int id);
        Task<List<UsuarioProjeto>> GetAllAsync();
        Task<List<UsuarioProjeto>> GetAllByUserId(int id);
        Task<List<UsuarioProjeto>> GetAllInvitesByUserId(int userId);
        Task<UsuarioProjeto> GetByUserAndProjectAsync(int userId, int projectId);
        Task<List<UsuarioProjeto>> GetAllUsersAndFunctionByProjectId(int id);
        Task<List<UsuarioProjeto>> GetAllUsersActiveInProjectById(int projectId);
        Task<List<Usuario>> GetAllByProjectId(int id);
        Task AddASync(UsuarioProjeto usuarioProjeto);
        Task SaveChangesAsync();
        Task DeleteUserProj(UsuarioProjeto usuarioProjeto);
    }
}