using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Enums;
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

        public async Task<List<Duvida>> GetAllByCursoAsync(int idCurso)
        {
            var projetoIdsDoCurso = await _context.UsuarioProjeto
                .Join(_context.Usuario,
                    up => up.IdUsuario,
                    u => u.Id,
                    (up, u) => new { up.IdProjeto, u.IdCurso })
                .Where(x => x.IdCurso == idCurso)
                .Select(x => x.IdProjeto)
                .Distinct()
                .ToListAsync();

            var duvidas = await _context.Duvida
                .Include(d => d.IdUsuarioNavigation)
                .Include(d => d.IdProjetoNavigation)
                .Include(d => d.RespostaDuvida)
                .Where(d => projetoIdsDoCurso.Contains(d.IdProjeto))
                .Where(d => d.Visibilidade == VisibilidadeDuvidaEnum.Publica)
                .ToListAsync();

            return duvidas;
        }

        public async Task<Duvida?> GetByIdAsync(int id)
        {
            return await _context.Duvida
                .Include(d => d.IdUsuarioNavigation)
                .Include(d => d.IdProjetoNavigation)
                .Include(d => d.RespostaDuvida)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<List<Duvida>> GetByProjetoAndAtendidaAsync(int idProjeto, RespotaDuvidaEnum atendida)
        {
            return await _context.Duvida
                .Where(d => d.IdProjeto == idProjeto && d.Atendida == atendida)
                .Include(d => d.IdUsuarioNavigation)
                .Include(d => d.RespostaDuvida)
                .ToListAsync();
        }

        public async Task<List<Duvida>> GetByProjetoIdAsync(int idProjeto)
        {
            return await _context.Duvida
                .Where(d => d.IdProjeto == idProjeto && d.Atendida == RespotaDuvidaEnum.Nao)
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

        public async Task MarcarComoAtendidaAsync(int idDuvida)
        {
            var duvida = await _context.Duvida.FindAsync(idDuvida);
            if (duvida == null)
                throw new Exception("Dúvida não encontrada");

            duvida.Atendida = RespotaDuvidaEnum.Sim;
            duvida.EditadoEm = DateTime.Now;

            _context.Duvida.Update(duvida);
            await _context.SaveChangesAsync();
        }
        public async Task MarcarComoNaoAtendidaAsync(int idDuvida)
        {
            var duvida = await _context.Duvida.FindAsync(idDuvida);
            if (duvida != null)
            {
                duvida.Atendida = RespotaDuvidaEnum.Nao;
                _context.Update(duvida);
                await _context.SaveChangesAsync();
            }
        }
    }
}
