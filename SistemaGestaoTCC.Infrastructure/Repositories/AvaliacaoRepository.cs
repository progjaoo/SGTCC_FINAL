using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private SGTCCContext _dbcontext;
        private IUsuarioProjetoRepository _usuarioProjetoRepository;
        private IProjectRepository _projectRepository;
        public AvaliacaoRepository(SGTCCContext dbcontext, IUserRepository userRepository, IUsuarioProjetoRepository usuarioProjetoRepository, IProjectRepository projectRepository)
        {
            _dbcontext = dbcontext;
            _usuarioProjetoRepository = usuarioProjetoRepository;
            _projectRepository = projectRepository;
        }
        public async Task<ProjetoAvaliacaoPublica> GetById(int id)
        {
            return await _dbcontext.ProjetoAvaliacaoPublica.SingleOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddASync(ProjetoAvaliacaoPublica avaliacao)
        {
            await _dbcontext.AddAsync(avaliacao);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<List<ProjetoAvaliacaoPublica>> GetAvaliacoesByUsuarioAsync(int idUsuario)
        {
            return await _dbcontext.ProjetoAvaliacaoPublica
                .Where(p => p.IdUsuario == idUsuario)
                .ToListAsync();
        }
        public async Task<List<ProjetoAvaliacaoPublica>> GetAvaliacoesByProjectAsync(int idProjeto)
        {
            return await _dbcontext.ProjetoAvaliacaoPublica
                .Where(p => p.IdProjeto == idProjeto)
                .ToListAsync();
        }
    }
}
