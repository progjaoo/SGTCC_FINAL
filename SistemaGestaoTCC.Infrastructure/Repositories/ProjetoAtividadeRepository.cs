using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
{
    public class ProjetoAtividadeRepository : IProjetoAtividadeRepository
    {
        private readonly SGTCCContext _dbContext;
        public ProjetoAtividadeRepository(SGTCCContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProjetoAtividade>> GetAllAsync()
        {
            return await _dbContext.ProjetoAtividade
                .Include(a => a.IdUsuarioNavigation)
                .ToListAsync();
        }
        public async Task<List<ProjetoAtividade>> GetByStatusAsync(ProjetoAtividadeEnum status, int idProjeto)
        {
            return await _dbContext.ProjetoAtividade
                   .Where(p => p.Estado == status && p.IdProjeto == idProjeto)
                   .Include(p=> p.IdUsuarioNavigation)
                   .ToListAsync();
        }
        public async Task<ProjetoAtividade> GetById(int id)
        {
            return await _dbContext.ProjetoAtividade.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task<List<ProjetoAtividade>> GetAtividadeByUserAsync(int idUsuario)
        {
            return await _dbContext.ProjetoAtividade
                .Where(a => a.IdUsuario == idUsuario)
                .Where(a => a.Estado == Core.Enums.ProjetoAtividadeEnum.Criada)
                .ToListAsync();
        }
        public async Task<List<ProjetoAtividade>> GetAtividadeByProjectIdAsync(int projectId)
        {
            return await _dbContext.ProjetoAtividade
                .Where(a => a.IdProjeto == projectId)
                .Where(a => a.Estado == Core.Enums.ProjetoAtividadeEnum.Criada)
                .Include(a => a.IdUsuarioNavigation)
                .ToListAsync();
        }
        public async Task<List<ProjetoAtividade>> GetAtividadeByProjectIdNoFilterAsync(int projectId)
        {
            return await _dbContext.ProjetoAtividade
                .Where(a => a.IdProjeto == projectId)
                .ToListAsync();
        }
        public async Task AddASync(ProjetoAtividade atividade)
        {
            await _dbContext.AddAsync(atividade);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAtividade(int id)
        {
            var atividade = await _dbContext.ProjetoAtividade.FindAsync(id);
            _dbContext.ProjetoAtividade.Remove(atividade);
            await _dbContext.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task FinalizarAtividade(int id)
        {
            var atividade = await _dbContext.ProjetoAtividade.FindAsync(id);

            if (atividade != null)
            {
                atividade.Finish();
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task AtualizarEstadoAsync(ProjetoAtividade atividade)
        {
            _dbContext.ProjetoAtividade.Update(atividade);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<ProjetoAtividade>> GetAtividadeByPrioridadeIdAsync(PrioridadeAtividadeEnum prioridade, int idProjeto)
        {
            return await _dbContext.ProjetoAtividade
                .Where(a => a.Prioridade == prioridade && a.IdProjeto == idProjeto)
                .Include(a => a.IdUsuarioNavigation)
                .ToListAsync();
        }
    }
}