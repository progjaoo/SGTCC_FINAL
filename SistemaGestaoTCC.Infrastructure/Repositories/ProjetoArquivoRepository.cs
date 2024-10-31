using Microsoft.EntityFrameworkCore;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Infrastructure.Repositories
{
    public class ProjetoArquivoRepository : IProjetoArquivoRepository
    {
        private readonly SGTCCContext _dbContext;

        public ProjetoArquivoRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddASync(ProjetoArquivo projetoArquivo)
        {
            await _dbContext.AddAsync(projetoArquivo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var projetoArq = await _dbContext.ProjetoArquivo.FindAsync(id);
            _dbContext.ProjetoArquivo.Remove(projetoArq);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProjetoArquivo>> GetAllAsync()
        {
            return await _dbContext.ProjetoArquivo.ToListAsync();
        }

        public async Task<ProjetoArquivo> GetById(int id)
        {
            return await _dbContext.ProjetoArquivo.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
