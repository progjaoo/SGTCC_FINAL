using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class ArquivoRepository : IArquivoRepository
    {
        private readonly SGTCCContext _context;

        public ArquivoRepository(SGTCCContext context)
        {
            _context = context;
        }

        public async Task<Arquivo> AddAsync(Arquivo arquivo)
        {
            await _context.Arquivo.AddAsync(arquivo);
            await _context.SaveChangesAsync();
            return arquivo;
        }

        public async Task<Arquivo> GetByIdAsync(int id)
        {
            return await _context.Arquivo
                .Include(a => a.ProjetoArquivos)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Arquivo>> GetAllAsync()
        {
            return await _context.Arquivo
                .Include(a => a.ProjetoArquivos)
                .ToListAsync();
        }

        public async Task UpdateAsync(Arquivo arquivo)
        {
            _context.Arquivo.Update(arquivo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var arquivo = await _context.Arquivo.FindAsync(id);
            _context.Arquivo.Remove(arquivo);
            await _context.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
