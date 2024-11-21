using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly SGTCCContext _dbcontext;
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;
        private readonly string _connectionString;

        public ProjectRepository(SGTCCContext dbcontext, IUsuarioProjetoRepository usuarioProjetoRepository, IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _usuarioProjetoRepository = usuarioProjetoRepository;
            _connectionString = configuration.GetConnectionString("SistemaTcc");
        }

        public async Task<List<Projeto>> GetAllAsync()
        {
            //ok 
            return await _dbcontext.Projeto
            //.Where(p => p.Estado == Core.Enums.StatusProjeto.Created)
            .Where(p => p.Aprovado == true)
            .ToListAsync();
        }

        public async Task<List<Projeto>> GetAllPendingAsync()
        {
            //ok
            return await _dbcontext.Projeto
            .Where(p => p.Estado == Core.Enums.StatusProjeto.Finished && p.Aprovado == false)
            .ToListAsync();
        }

        public async Task<List<Projeto>> GetAllByUserAsync(int id)
        {
            //ok
            var idsProjetos = (await _usuarioProjetoRepository.GetAllByUserId(id)).Select(p => p.IdProjeto);
            return await _dbcontext.Projeto.Where(p => idsProjetos.Contains(p.Id)).ToListAsync();
        }
        public async Task<List<Projeto>> GetAllActiveByUserAsync(int id)
        {
            var idsProjetos = (await _usuarioProjetoRepository.GetAllByUserId(id)).Select(p => p.IdProjeto);

            return await _dbcontext.Projeto
                .Where(p => idsProjetos.Contains(p.Id) && p.Estado != Core.Enums.StatusProjeto.Canceled)
                .ToListAsync();
        }
        public async Task<Projeto> GetById(int id)
        {
            return await _dbcontext.Projeto.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Projeto> GetDetailsByIdAsync(int id)
        {
            return await _dbcontext.Projeto.SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddASync(Projeto projeto)
        {
            await _dbcontext.Projeto.AddAsync(projeto);
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
        public async Task StartAsync(Projeto projeto)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Projects SET Estado = @estado, DataInicio = @datainicio WHERE Id = @id";

                await sqlConnection.ExecuteAsync(script, new { estado = projeto.Estado, datainicio = projeto.DataInicio, projeto.Id });
            }
        }
        public async Task Finalizar(int id)
        {
            var projeto = await _dbcontext.Projeto.FindAsync(id);

            if (projeto != null)
            {
                projeto.Finish();
                projeto.DataFim = DateTime.Now;
                await _dbcontext.SaveChangesAsync();
            }
        }
        public async Task TornarPublico(int id)
        {
            var projeto = await _dbcontext.Projeto.FindAsync(id);

            if (projeto != null)
            {
                projeto.Aprovado = !projeto.Aprovado;

                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}