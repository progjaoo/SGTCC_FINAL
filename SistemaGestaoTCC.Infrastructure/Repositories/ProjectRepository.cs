using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Infrastructure.Repositories
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
        public async Task<List<Projeto>> GetAllByFilterAsync(FiltroEnum filterEnum, string filter, OrdenaEnum sortEnum, string? ano)
        {
            var projetos = await _dbcontext.Projeto.ToListAsync();
            if (ano != null)
            {
                projetos = projetos
                .Where(p => p.DataFim.HasValue)
                .Where(p => p.DataFim.Value.ToString("dd-MM-yyyy") == ano)
                .ToList();
            }

            switch (filterEnum)
            {
                case FiltroEnum.NomeUsuario:
                    projetos = projetos
                    .Join(_dbcontext.UsuarioProjeto,
                        p => p.Id,
                        up => up.IdProjeto,
                        (p, up) => new { Projeto = p, UsuarioProjeto = up })
                    .Join(_dbcontext.Usuario,
                        temp => temp.UsuarioProjeto.IdUsuario,
                        u => u.Id,
                        (temp, u) => new
                        {
                            temp = temp,
                            Usuario = u
                        })
                    .Where(temp2 => temp2.Usuario.Nome == filter)
                    .Select(temp2 => temp2.temp.Projeto)
                    .ToList();
                    break;

                case FiltroEnum.NomeProjeto:
                    projetos = projetos.Where(p => p.Nome == filter).ToList();
                    break;

                case FiltroEnum.Tag:
                    projetos = projetos
                    .Join(_dbcontext.ProjetoTag,
                    p => p.Id,
                    pt => pt.IdProjeto,
                    (p, pt) => new { Projeto = p, ProjetoTag = pt })
                    .Where(projetao => projetao.ProjetoTag.Nome == filter)
                    .Select(projetao => projetao.Projeto)
                    .ToList();
                    break;

                default:
                    throw new HttpRequestException("Tipo de Filtro Incorreto");
            }

            switch (sortEnum)
            {
                case OrdenaEnum.Recentes:
                    projetos = projetos.OrderByDescending(p => p.DataFim).ToList();
                    break;
                case OrdenaEnum.Antigos:
                    projetos = projetos.OrderBy(p => p.DataFim).ToList();
                    break;
            }
            return projetos;
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