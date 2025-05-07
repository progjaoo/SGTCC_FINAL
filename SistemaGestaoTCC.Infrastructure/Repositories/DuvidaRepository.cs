using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class DuvidaRepository : IDuvidaRepository
    {
        private readonly SGTCCContext _context;

        public DuvidaRepository(SGTCCContext context)
        {
            _context = context;
        }

        public async Task<List<Duvida>> GetAllAsync()
        {
            return await _context.Duvida
                .Include(d => d.IdUsuarioNavigation)
                .Include(d => d.IdProjetoNavigation)
                .Include(d => d.RespostaDuvida)
                .ToListAsync();
        }

        public async Task<Duvida?> GetByIdAsync(int id)
        {
            return await _context.Duvida
                .Include(d => d.IdUsuarioNavigation)
                .Include(d => d.IdProjetoNavigation)
                .Include(d => d.RespostaDuvida)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Duvida>> GetByProjetoIdAsync(int idProjeto)
        {
            return await _context.Duvida
                .Where(d => d.IdProjeto == idProjeto)
                .Include(d => d.IdUsuarioNavigation)
                .Include(d => d.RespostaDuvida)
                .ToListAsync();
        }

        public async Task<List<Duvida>> GetByUsuarioIdAsync(int idUsuario)
        {
            return await _context.Duvida
                .Where(d => d.IdUsuario == idUsuario)
                .Include(d => d.IdProjetoNavigation)
                .Include(d => d.RespostaDuvida)
                .ToListAsync();
        }

        public async Task AddAsync(Duvida duvida)
        {
            await _context.Duvida.AddAsync(duvida);
        }

        public async Task Delete(int id)
        {
            var duvidas = await _context.Duvida.FindAsync(id);
            _context.Duvida.Remove(duvidas);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
