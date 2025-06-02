using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class CampoDocumentoRepository : ICampoDocumentoRepository
    {
        private readonly SGTCCContext _dbContext;

        public CampoDocumentoRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CampoDocumentoAvaliacaoAluno>> GetAllAsync()
        {
            return await _dbContext.CampoDocumentoAvaliacaoAluno.ToListAsync();
        }
        public async Task<List<CampoDocumentoAvaliacaoAluno>> GetAllByCategoryAsync(int idCategoria)
        {
            return await _dbContext.CampoDocumentoAvaliacaoAluno
                .Where(c => c.IdCategoria == idCategoria)
                .ToListAsync();
        }

        public async Task<CampoDocumentoAvaliacaoAluno> GetByIdAsync(int id)
        {
            return await _dbContext.CampoDocumentoAvaliacaoAluno
                .Include(c => c.IdCategoriaNavigation)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task AddAsync(CampoDocumentoAvaliacaoAluno campoDocumentoAvaliacaoAluno)
        {
            await _dbContext.CampoDocumentoAvaliacaoAluno.AddAsync(campoDocumentoAvaliacaoAluno);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var campo = await GetByIdAsync(id);
            if (campo != null)
            {
                _dbContext.CampoDocumentoAvaliacaoAluno.Remove(campo);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();

        }
    }
}
