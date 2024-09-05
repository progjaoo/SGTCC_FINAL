using Microsoft.EntityFrameworkCore;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Infrastructure.Repositories
{
    public class ProjetoAtividadeRepository : IProjetoAtividadeRepository
    {
        private readonly SGTCCContext _dbContext;
        public ProjetoAtividadeRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProjetoAtividade>> GetAllAsync()
        {
            return await _dbContext.ProjetoAtividade.ToListAsync();
        }

        public async Task<ProjetoAtividade> GetById(int id)
        {
            return await _dbContext.ProjetoAtividade.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddASync(ProjetoAtividade atividade)
        {
            await _dbContext.AddAsync(atividade);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAtividade(int id)
        {
            var atividade = await _dbContext.ProjetoAtividade.FindAsync(id);
            _dbContext.ProjetoAtividade.Remove(atividade);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
