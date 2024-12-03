using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class NotasDocumentoAlunoRepository : INotasDocumentoAlunoRepository
    {
        private readonly SGTCCContext _dbContext;
        public NotasDocumentoAlunoRepository(SGTCCContext context)
        {
            _dbContext = context;
        }
        public async Task<NotaDocumentoAluno> GetByIdAsync(int id)
        {
            return await _dbContext.NotaDocumentoAluno.SingleOrDefaultAsync(c => c.Id == id);

        }
        public async Task<List<NotaDocumentoAluno>> GetAllAsync()
        {
            return await _dbContext.NotaDocumentoAluno.ToListAsync();
        }
        public async Task AddAsync(NotaDocumentoAluno notaDocumento)
        {
            await _dbContext.NotaDocumentoAluno.AddAsync(notaDocumento);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var notaDocumento = await _dbContext.NotaDocumentoAluno.FindAsync(id);
            _dbContext.NotaDocumentoAluno.Remove(notaDocumento);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
