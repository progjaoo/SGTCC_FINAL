using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class ProjetoEntregaProjetoRepository : IProjetoEntregaProjetoRepository
    {
        private readonly SGTCCContext _dbContext;

        public ProjetoEntregaProjetoRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ProjetoEntregaProjeto projetoEntregaProjeto)
        {
            await _dbContext.ProjetoEntregaProjetos.AddAsync(projetoEntregaProjeto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProjetoEntrega(ProjetoEntregaProjeto projetoEntregaProjeto)
        {
            _dbContext.ProjetoEntregaProjetos.Remove(projetoEntregaProjeto);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<ProjetoEntregaProjeto>> GetAllAsync()
        {
            return await _dbContext.ProjetoEntregaProjetos.ToListAsync();
        }

        public async Task<ProjetoEntregaProjeto> GetById(int id)
        {
            return await _dbContext.ProjetoEntregaProjetos.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<ProjetoEntregaProjeto> GetByProjectAndEntregaAsync(int projetoId, int entregaId)
        {
            return await _dbContext.ProjetoEntregaProjetos.SingleOrDefaultAsync(up => up.IdProjeto == projetoId && up.IdEntrega == entregaId);
        }
    }
}
