using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SGTCCContext _dbContext;

        public CategoriaRepository(SGTCCContext context)
        {
            _dbContext = context;
        }

        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _dbContext.Categoria.SingleOrDefaultAsync(c => c.Id == id);

        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _dbContext.Categoria.ToListAsync();
        }

        public async Task AddAsync(Categoria categoria)
        {
            await _dbContext.Categoria.AddAsync(categoria);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var categoria = await _dbContext.Categoria.FindAsync(id);
            _dbContext.Categoria.Remove(categoria);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
