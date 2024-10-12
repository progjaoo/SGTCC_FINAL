using Microsoft.EntityFrameworkCore;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Infrastructure.Repositories
{
    public class NotaFinalAlunoRepository : INotaFinalAlunoRepository
    {
        private readonly SGTCCContext _dbContext;
        public NotaFinalAlunoRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<NotaFinalAluno>> GetAllAsync()
        {
            return await _dbContext.NotaFinalAluno.ToListAsync();
        }

        public async Task<NotaFinalAluno> GetByIdAsync(int id)
        {
            return await _dbContext.NotaFinalAluno.SingleOrDefaultAsync(n => n.Id == id);
        }

        public async Task AddAsync(NotaFinalAluno notaFinal)
        {
            await _dbContext.AddAsync(notaFinal);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var notaFinal = await _dbContext.NotaFinalAluno.FindAsync(id);
            _dbContext.NotaFinalAluno.Remove(notaFinal);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(NotaFinalAluno notaFinal)
        {
            _dbContext.NotaFinalAluno.Update(notaFinal);
            await _dbContext.SaveChangesAsync();
        }
    }
}
