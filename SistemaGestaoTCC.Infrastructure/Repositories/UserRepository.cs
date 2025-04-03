using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SGTCCContext _dbcontext;

        public UserRepository(SGTCCContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task LoadCursoAsync(Usuario user)
        {
            await _dbcontext.Entry(user)
                .Reference(u => u.IdCursoNavigation)
                .LoadAsync();
        }
        public async Task<List<Usuario>> GetAllUserByCourse(int idCurso)
        {

            return await _dbcontext.Usuario.Where(c => c.IdCurso == idCurso)
                .Include(u => u.IdImagemNavigation)
                .Include(u => u.IdCursoNavigation)
                .ToListAsync();
        }
        public async Task<List<Usuario>> FilterUsers(PapelEnum papel, string nome)
        {
            return await _dbcontext.Usuario.Where(u => u.Papel == papel)
                .Where(u => u.Nome.Contains(nome))
                .Include(u => u.IdImagemNavigation)
                .Include(u => u.IdCursoNavigation)
                .Take(5)
                /*.OrderByDescending(u => u.UltimoAcesso ?? DateTime.MinValue)*/.ToListAsync();

        }
        public async Task<List<Usuario>> GetProfessoresAsync()
        {
            return await _dbcontext.Usuario
                .Where(u => u.Papel == PapelEnum.Professor)
                .Include(u => u.IdImagemNavigation)
                .Include(u => u.IdCursoNavigation)
                .ToListAsync();
        }
        public async Task<List<Usuario>> GetAllUserByRole(PapelEnum papel)
        {
            return await _dbcontext.Usuario.Where(u => u.Papel == papel)
                .Include(u => u.IdImagemNavigation)
                .Include(u => u.IdCursoNavigation)
                .ToListAsync();
        }
        public async Task<Usuario> GetById(int id)
        {
            return await _dbcontext.Usuario
                .AsNoTracking()
                .Include(u => u.IdCursoNavigation)
                .Include(u => u.IdImagemNavigation)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Usuario> GetByEmailByPassword(string email, string passwordHash)
        {
            return await _dbcontext.Usuario
                .Include(u => u.IdCursoNavigation)
                .Include(u => u.IdImagemNavigation)
                .SingleOrDefaultAsync(u => u.Email == email && u.Senha == passwordHash);
        }
        public async Task<Usuario> GetByEmail(string email)
        {
            return await _dbcontext.Usuario
                .Include(u => u.IdCursoNavigation)
                .Include(u => u.IdImagemNavigation)
                .SingleOrDefaultAsync(u => u.Email == email);
        }
        public async Task UpdateAsync(Usuario usuario)
        {
            _dbcontext.Usuario.Update(usuario);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();

        }
        //DELETE 
        public async Task RemoverAsync(Usuario usuario)
        {
            _dbcontext.Remove(usuario);
        }
        public async Task DeleteUser(int id)
        {
            var obj = await _dbcontext.Usuario.SingleOrDefaultAsync(p => p.Id == id);

            if (obj == null)
                throw new Exception("O Usuario nao existe");
            await RemoverAsync(obj);

        }
        public async Task<Usuario> GetUserByEmailAsync(string email)
        {
            return await _dbcontext.Usuario
                .Include(u => u.IdImagemNavigation)
                .Include(u => u.IdCursoNavigation)
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
