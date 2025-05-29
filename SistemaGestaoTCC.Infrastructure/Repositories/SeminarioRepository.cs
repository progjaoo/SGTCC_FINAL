using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class SeminarioRepository : ISeminarioRepository
    {
        private readonly SGTCCContext _dbContext;
        public SeminarioRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Seminario>> GetAllAsync()
        {
            return await _dbContext.Seminario
                .Include(s => s.IdUsuarioNavigation)
                .ToListAsync();
        }
        public async Task<List<Seminario>> GetAllByProjectId(int idProjeto)
        {
            return await _dbContext.Seminario
                .Where(s => s.SeminarioProjetos.Any(sp => sp.IdProjeto == idProjeto))
                .ToListAsync();
        }

        public async Task<Seminario> GetById(int id)
        {
            return await _dbContext.Seminario
                .Include(s => s.IdUsuarioNavigation)
                .Include(s => s.SeminarioProjetos)
                .ThenInclude(sp => sp.IdProjetoNavigation)
                .SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task AddASync(Seminario seminario)
        {
            await _dbContext.AddAsync(seminario);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var seminario = await _dbContext.Seminario.FindAsync(id);
            if (seminario != null)
            {
                _dbContext.Seminario.Remove(seminario);
                await _dbContext.SaveChangesAsync();
            }
        }
        #region */* - SEMINARIOPROJETO METHODS
        public async Task<List<SeminarioProjeto>> GetAllSeminarioProjeto()
        {
            return await _dbContext.SeminarioProjeto
                .Include(s => s.IdProjetoNavigation)
                    .ThenInclude(p => p.UsuarioProjetos)
                        .ThenInclude(up => up.IdUsuarioNavigation)
                .ToListAsync();
        }
        public async Task<SeminarioProjeto> GetSeminarioProjetoByIdAsync(int id)
        {
            return await _dbContext.SeminarioProjeto
                .Include(sp => sp.IdSeminarioNavigation)
                .Include(sp => sp.IdProjetoNavigation)
                .SingleOrDefaultAsync(sp => sp.Id == id);
        }
        public async Task AddSeminarioProjeto(SeminarioProjeto seminarioProjeto)
        {
            await _dbContext.AddAsync(seminarioProjeto);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteSeminarioProjeto(int id)
        {
            var seminarioProjeto = await _dbContext.SeminarioProjeto.FindAsync(id);
            if (seminarioProjeto != null)
            {
                _dbContext.SeminarioProjeto.Remove(seminarioProjeto);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SeminarioProjeto> GetByProjectAndSeminario(int idSeminario, int idProjeto)
        {
            return await _dbContext.SeminarioProjeto.SingleOrDefaultAsync(up => up.IdSeminario == idSeminario && up.IdProjeto == idProjeto);
        }
        #endregion
    }
}