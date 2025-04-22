using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class AnotacaoRepository : IAnotacaoRepository
    {
        private readonly SGTCCContext _dbContext;
        public AnotacaoRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Anotacao anotacao)
        {
            await _dbContext.Anotacao.AddAsync(anotacao);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Anotacao>> GetAllAsync()
        {
            return await _dbContext.Anotacao.ToListAsync();
        }

        public async Task<List<Anotacao>> GetAnotacaoByIdProjectAsync(int idProjeto)
        {
            return await _dbContext.Anotacao
                .Where(a => a.IdProjeto == idProjeto)
                .Include(a => a.IdUsuarioNavigation)
                .Include(a => a.IdProjetoNavigation)
                .ToListAsync();
        }
        public async Task<List<Anotacao>> GetAnotacaoByUserAsync(int idUsuario)
        {
            return await _dbContext.Anotacao
                    .Where(a => a.IdUsuario == idUsuario)
                    .Include(a => a.IdUsuarioNavigation)
                    .Include(a => a.IdProjetoNavigation)
                    .ToListAsync();
        }
        public async Task<Anotacao> GetById(int id)
        {
            return await _dbContext.Anotacao.SingleOrDefaultAsync(a => a.Id == id);
        }
        public async Task DeleteAsync(int id)
        {
            var anotacao = await _dbContext.Anotacao.FindAsync(id);
            _dbContext.Anotacao.Remove(anotacao);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
