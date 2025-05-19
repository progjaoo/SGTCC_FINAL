using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Usuario>> GetAllUserByCourse(int idCurso);
        Task<List<Usuario>> FilterUsers(PapelEnum papel, string nome);
        Task<List<Usuario>> GetAllUserByRole(PapelEnum papel);

        Task<List<Usuario>> GetProfessoresAsync();
        Task<Usuario> GetById(int id);
        Task<Usuario> GetByEmailByPassword(string email, string passwordHash);
        Task<Usuario> GetVerifiedUserByEmailAndPassword(string email, string passwordHash);
        Task<Usuario> GetByEmail(string email);
        //Task<bool> SetEmailVerificado(int userId);
        Task UpdateAsync(Usuario usuario);
        Task DefinirCursoAsync(int idUsuario, int idCurso);
        Task SaveChangesAsync();
        Task DeleteUser(int id);
        Task LoadCursoAsync(Usuario user);
        Task<Usuario> GetUserByEmailAsync(string email);
        Task<Usuario> GetByIdAsync(int id);
    }
}
