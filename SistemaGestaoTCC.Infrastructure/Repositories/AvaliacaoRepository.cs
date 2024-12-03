using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private SGTCCContext _dbcontext;
        private IUsuarioProjetoRepository _usuarioProjetoRepository;
        public AvaliacaoRepository(SGTCCContext dbcontext, IUserRepository userRepository, IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _dbcontext = dbcontext;
            _usuarioProjetoRepository = usuarioProjetoRepository;
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
            var avaliacoes = (await _usuarioProjetoRepository.GetAllByUserId(idUsuario)).Select(p => p.IdProjeto);
            return await _dbcontext.ProjetoAvaliacaoPublica.Where(p => avaliacoes.Contains(p.Id)).ToListAsync();
        }
    }
}