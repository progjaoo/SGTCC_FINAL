using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class AvaliadorBancaRepository : IAvaliadorBancaRepository
    {
        private readonly SGTCCContext _dbContext;

        public AvaliadorBancaRepository(SGTCCContext context)
        {
            _dbContext = context;
        }
        public async Task<AvaliadorBanca> GetByIdAsync(int id)
        {
            return await _dbContext.AvaliadorBanca
                .Include(ab => ab.IdBancaNavigation)
                .Include(ab => ab.IdUsuarioNavigation)
                .FirstOrDefaultAsync(ab => ab.Id == id);
        }

        public async Task<List<AvaliadorBanca>> GetByBancaIdAsync(int bancaId)
        {
            return await _dbContext.AvaliadorBanca
                .Where(ab => ab.IdBanca == bancaId)
                .Include(ab => ab.IdBancaNavigation)
                .Include(ab => ab.IdUsuarioNavigation)
                .ToListAsync();
        }
        public async Task<List<AvaliadorBanca>> GetAllAsync()
        {
            return await _dbContext.AvaliadorBanca
                .Include(ab => ab.IdBancaNavigation)
                .Include(ab => ab.IdUsuarioNavigation)
                .ToListAsync();
        }
        public async Task AddAsync(AvaliadorBanca avaliadorBanca)
        {
            await _dbContext.AvaliadorBanca.AddAsync(avaliadorBanca);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(AvaliadorBanca avaliadorBanca)
        {
            _dbContext.AvaliadorBanca.Update(avaliadorBanca);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var avabanca = await _dbContext.AvaliadorBanca.FindAsync(id);
            _dbContext.AvaliadorBanca.Remove(avabanca);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}