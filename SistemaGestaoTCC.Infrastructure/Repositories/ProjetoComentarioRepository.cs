using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class ProjetoComentarioRepository : IProjetoComentarioRepository
    {
        private readonly SGTCCContext _dbContext;
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;
        public ProjetoComentarioRepository(SGTCCContext dbContext, IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _dbContext = dbContext;
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }

        public async Task<List<ProjetoComentario>> GetAllAsync()
        {
            return await _dbContext.ProjetoComentario.ToListAsync();
        }

        public async Task<ProjetoComentario> GetById(int id)
        {
            return await _dbContext.ProjetoComentario.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddASync(ProjetoComentario comentario)
        {
            await _dbContext.AddAsync(comentario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteComentario(int id)
        {
            var coment = await _dbContext.ProjetoComentario.FindAsync(id);
            _dbContext.ProjetoComentario.Remove(coment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProjetoComentario>> GetAllCommentsByProject(int projectId)
        {
            return await _dbContext.ProjetoComentario
            .Where(pc => pc.IdProjeto == projectId)
            .ToListAsync();
        }

        public async Task<IEnumerable<ProjetoComentario>> GetAllCommentsByUser(int userId)
        {
            return await _dbContext.ProjetoComentario
                        .Where(pc => pc.IdUsuario == userId)
                        .ToListAsync();
        }
    }
}