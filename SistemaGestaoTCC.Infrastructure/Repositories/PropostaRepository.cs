using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly SGTCCContext _dbContext;
        public PropostaRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Proposta>> GetAllAsync()
        {
            return await _dbContext.Proposta
                .Include(p => p.IdProjetoNavigation) 
                .ToListAsync(); 
        }
        public async Task<Proposta> GetByIdAsync(int id)
        {
            return await _dbContext.Proposta
                .Include(p => p.IdProjetoNavigation)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Proposta proposta)
        {
            await _dbContext.Proposta.AddAsync(proposta);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var proposta = await _dbContext.Proposta.FindAsync(id);
            _dbContext.Proposta.Remove(proposta);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> AtualizarParecerAsync(int idProposta, ParecerPropostaEnum novoParecer)
        {
            var proposta = await _dbContext.Proposta
                .Include(p => p.IdProjetoNavigation) 
                .FirstOrDefaultAsync(p => p.Id == idProposta);

            if (proposta == null)
            {
                return false;
            }

            proposta.Parecer = novoParecer;
            proposta.EditadoEm = DateTime.Now;

            if (proposta.IdProjetoNavigation != null)
            {
                proposta.IdProjetoNavigation.PropostaAprovada = (int?)novoParecer;
            }

            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<List<Proposta>> GetPropostaByProject(int idProjeto)
        {
            return await _dbContext.Proposta
                            .Where(a => a.IdProjeto == idProjeto)
                            .Include(a => a.IdProjetoNavigation)
                            .ToListAsync();
        }
    }
}