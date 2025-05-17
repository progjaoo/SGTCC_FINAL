using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class BancaRepository : IBancaRepository
    {
        private readonly SGTCCContext _dbContext;
        public BancaRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Banca>> GetAllAsync()
        {
            return await _dbContext.Banca.ToListAsync();
        }
        public async Task<Banca> GetById(int id)
        {
            return await _dbContext.Banca
               .Include(b => b.IdProjetoNavigation)
                   .ThenInclude(p => p.UsuarioProjetos)
                       .ThenInclude(up => up.IdUsuarioNavigation)
               .Include(b => b.AvaliadorBancas)
                   .ThenInclude(ab => ab.IdUsuarioNavigation) 
               .Include(b => b.AvaliadorBancas)
                   .ThenInclude(ab => ab.NotaFinalAlunos)     
                       .ThenInclude(nf => nf.IdAlunoNavigation)
               .SingleOrDefaultAsync(b => b.Id == id);
        }
        public async Task AddASync(Banca banca)
        {
            await _dbContext.AddAsync(banca);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteBanca(int id)
        {
            var banca = await _dbContext.Banca.FindAsync(id);
            _dbContext.Banca.Remove(banca);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
