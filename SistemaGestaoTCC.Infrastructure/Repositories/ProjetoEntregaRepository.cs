using Microsoft.EntityFrameworkCore;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Infrastructure.Repositories
{
    public class ProjetoEntregaRepository : IProjetoEntregaRepository
    {
        private readonly SGTCCContext _dbContext;
        public ProjetoEntregaRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProjetoEntrega>> GetAllAsync()
        {
            return await _dbContext.ProjetoEntrega.ToListAsync();
        }

        public async Task<ProjetoEntrega> GetByIdAsync(int id)
        {
            return await _dbContext.ProjetoEntrega.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(ProjetoEntrega projetoEntrega)
        {
            await _dbContext.AddAsync(projetoEntrega);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var projeto = await _dbContext.ProjetoEntrega.FindAsync(id);
            _dbContext.Remove(projeto);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
