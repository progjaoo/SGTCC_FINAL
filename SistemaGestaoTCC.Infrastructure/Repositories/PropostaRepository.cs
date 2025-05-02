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
            return await _dbContext.Proposta.ToListAsync(); 
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

        public async Task<bool> AtualizarParecerAsync(int idProjeto, ParecerPropostaEnum novoParecer)
        {
            var proposta = await _dbContext.Proposta.FindAsync(idProjeto);

            if (proposta == null)
            {
                return false;
            }

            proposta.Parecer = novoParecer;
            proposta.EditadoEm = DateTime.UtcNow;
            
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
    }
}