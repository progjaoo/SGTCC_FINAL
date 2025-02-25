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
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
