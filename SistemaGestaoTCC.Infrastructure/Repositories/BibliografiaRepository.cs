using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class BibliografiaRepository : IBibliografiaRepository
    {
        private readonly SGTCCContext _dbContext;
        public BibliografiaRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Bibliografia>> GetAllAsync()
        {
            return await _dbContext.Bibliografia.ToListAsync();
        }

        public async Task<Bibliografia> GetById(int id)
        {
            return await _dbContext.Bibliografia.SingleOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddAsync(Bibliografia bibliografia)
        {
            await _dbContext.Bibliografia.AddAsync(bibliografia);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bibliografia = await _dbContext.Bibliografia.FindAsync(id);
            _dbContext.Bibliografia.Remove(bibliografia);
            await _dbContext.SaveChangesAsync();
        }


        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
