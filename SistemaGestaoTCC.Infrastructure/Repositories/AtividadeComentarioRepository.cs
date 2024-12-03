using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class AtividadeComentarioRepository : IAtividadeComentarioRepository
    {
        private readonly SGTCCContext _dbContext;

        public AtividadeComentarioRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AtividadeComentario>> GetAllAsync()
        {
            return await _dbContext.AtividadeComentario.ToListAsync();
        }
        public async Task<AtividadeComentario> GetById(int id)
        {
            return await _dbContext.AtividadeComentario.SingleOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddASync(AtividadeComentario atividadeComentario)
        {
            await _dbContext.AddAsync(atividadeComentario);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var atividade = await _dbContext.AtividadeComentario.FindAsync(id);
            _dbContext.Remove(atividade);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
