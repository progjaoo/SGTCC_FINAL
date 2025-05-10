using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class UsuarioProjetoRepository : IUsuarioProjetoRepository
    {
        private readonly SGTCCContext _dbcontext;

        public UsuarioProjetoRepository(SGTCCContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<UsuarioProjeto>> GetAllAsync()
        {
            return await _dbcontext.UsuarioProjeto.ToListAsync();
        }

        public async Task<List<UsuarioProjeto>> GetAllByUserId(int id)
        {
            return await _dbcontext.UsuarioProjeto.Where(up => up.IdUsuario == id).ToListAsync();
        }

        public async Task<List<Usuario>> GetAllByProjectId(int id)
        {
            var listUserProject = await _dbcontext.UsuarioProjeto.Where(up => up.IdProjeto == id && up.Estado == ConviteEnum.Aceito).Select(up => up.IdUsuario).ToListAsync();

            return await _dbcontext.Usuario
            .Where(p => listUserProject.Contains(p.Id))
            .ToListAsync();
        }
        public async Task<List<UsuarioProjeto>> GetAllInvitesByUserId(int userId)
        {
            return await _dbcontext.UsuarioProjeto
                .Where(p => p.IdUsuario == userId)
                .Where(p => p.Estado == ConviteEnum.Pendente)
                .Include(up => up.IdUsuarioNavigation)
                .Include(up => up.IdProjetoNavigation)
                    .ThenInclude(u => u.IdImagemNavigation)
                .ToListAsync();
        }
        public async Task<List<UsuarioProjeto>> GetAllUsersAndFunctionByProjectId(int id)
        {
            var result = await _dbcontext.UsuarioProjeto
                .Where(up => up.IdProjeto == id )
                .Include(up => up.IdUsuarioNavigation)
                    .ThenInclude(u => u.IdImagemNavigation)
                .ToListAsync();

            return result;
        }
        public async Task<List<UsuarioProjeto>> GetAllUsersActiveInProjectById(int projectId)
        {
            var result = await _dbcontext.UsuarioProjeto
                .Where(up => up.IdProjeto == projectId && up.Estado == ConviteEnum.Aceito)
                .Include(up => up.IdUsuarioNavigation)
                    .ThenInclude(u => u.IdImagemNavigation)
                .ToListAsync();

            return result;
        }
        public async Task<UsuarioProjeto> GetById(int id)
        {
            return await _dbcontext.UsuarioProjeto.SingleOrDefaultAsync(up => up.Id == id);

        }
        public async Task<UsuarioProjeto> GetByUserAndProjectAsync(int userId, int projectId)
        {
            return await _dbcontext.UsuarioProjeto.SingleOrDefaultAsync(up => up.IdUsuario == userId && up.IdProjeto == projectId);
        }
        public async Task AddASync(UsuarioProjeto usuarioProjeto)
        {
            await _dbcontext.UsuarioProjeto.AddAsync(usuarioProjeto);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public async Task DeleteUserProj(UsuarioProjeto usuarioProjeto)
        {
            _dbcontext.UsuarioProjeto.Remove(usuarioProjeto);
            await _dbcontext.SaveChangesAsync();
        }
    }
}