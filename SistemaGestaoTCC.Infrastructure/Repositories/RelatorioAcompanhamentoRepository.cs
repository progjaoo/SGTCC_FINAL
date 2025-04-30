using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class RelatorioAcompanhamentoRepository : IRelatorioAcompanhamentoRepository
    {
        private readonly SGTCCContext _dbContext;
        public RelatorioAcompanhamentoRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(RelatorioAcompanhamento relatorio)
        {
            await _dbContext.RelatorioAcompanhamento.AddAsync(relatorio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var relatorio = await _dbContext.RelatorioAcompanhamento.FindAsync(id);
            _dbContext.RelatorioAcompanhamento.Remove(relatorio);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<RelatorioAcompanhamento>> GetAllAsync()
        {
            return await _dbContext.RelatorioAcompanhamento.ToListAsync();
        }

        public async Task<RelatorioAcompanhamento> GetById(int id)
        { 
            return await _dbContext.RelatorioAcompanhamento.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<RelatorioAcompanhamento>> GetRelatorioByProjectAsync(int idProjeto)
        {
            return await _dbContext.RelatorioAcompanhamento
                            .Where(a => a.IdProjeto == idProjeto)
                            .Include(a => a.IdUsuarioNavigation)
                            .Include(a => a.IdProjetoNavigation)
                            .ToListAsync();
        }
        public async Task<List<RelatorioAcompanhamento>> GetRelatorioByUserAsync(int idUsuario)
        {
            return await _dbContext.RelatorioAcompanhamento
                            .Where(a => a.IdProfessor == idUsuario)
                            .Include(a => a.IdUsuarioNavigation)
                            .Include(a => a.IdProjetoNavigation)
                            .ToListAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
