using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class RespostaDuvidaRepository : IRespostaDuvidaRepository
    {
        private readonly SGTCCContext _context;

        public RespostaDuvidaRepository(SGTCCContext context)
        {
            _context = context;
        }

        public async Task<List<RespostaDuvida>> GetAllAsync()
        {
            return await _context.RespostaDuvida
                .Include(r => r.IdUsuarioNavigation)
                .Include(r => r.IdDuvidaNavigation)
                .ToListAsync();
        }

        public async Task<RespostaDuvida?> GetByIdAsync(int id)
        {
            return await _context.RespostaDuvida
                .Include(r => r.IdUsuarioNavigation)
                .Include(r => r.IdDuvidaNavigation)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<RespostaDuvida>> GetByDuvidaIdAsync(int idDuvida)
        {
            return await _context.RespostaDuvida
                .Include(r => r.IdUsuarioNavigation)
                .Where(r => r.IdDuvida == idDuvida)
                .ToListAsync();
        }

        public async Task<List<RespostaDuvida>> GetByUsuarioIdAsync(int idUsuario)
        {
            return await _context.RespostaDuvida
                .Include(r => r.IdDuvidaNavigation)
                .Where(r => r.IdUsuario == idUsuario)
                .ToListAsync();
        }
        public async Task Delete(int id)
        {
            var respostaDuvidas = await _context.RespostaDuvida.FindAsync(id);
            _context.RespostaDuvida.Remove(respostaDuvidas);
            await _context.SaveChangesAsync();
        }
        public async Task AddAsync(RespostaDuvida resposta)
        {
            await _context.RespostaDuvida.AddAsync(resposta);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
