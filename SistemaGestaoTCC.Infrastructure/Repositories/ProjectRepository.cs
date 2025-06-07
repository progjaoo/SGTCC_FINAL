using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using System.Globalization;
using System.Text;

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
            .Include(p => p.ProjetoTags)
            .Include(p => p.IdImagemNavigation)
            .ToListAsync();
        }
        public async Task<List<Projeto>> GetAllPendingByNameAsync(string nome)
        {
            var padrao = RemoveAccents(nome.ToLower());

            var projetos = await _dbcontext.Projeto
                .Where(p => p.Estado == Core.Enums.StatusProjeto.Finished && p.Aprovado == false)
                .Include(p => p.ProjetoTags)
                .ToListAsync();

            return projetos.Where(p => RemoveAccents(p.Nome.ToLower()).Contains(padrao)).ToList();
        }
        public async Task<List<Projeto>> GetAllPendingAsync()
        {
            //ok
            return await _dbcontext.Projeto
            .Where(p => p.Estado == Core.Enums.StatusProjeto.Finished && p.Aprovado == false)
            .Include(p => p.ProjetoTags)
            .ToListAsync();
        }

        public async Task<List<Projeto>> GetAllByUserAsync(int id)
        {
            //ok
            var idsProjetos = (await _usuarioProjetoRepository.GetAllByUserId(id)).Select(p => p.IdProjeto);
            return await _dbcontext.Projeto.Where(p => idsProjetos.Contains(p.Id))
                .Include(p => p.ProjetoTags)
                .ToListAsync();
        }
        public async Task<List<Projeto>> GetAllByUserFavoriteAsync(int id)
        {
            var idsProjetos = await _dbcontext.ProjetoAvaliacaoPublica
                .Where(p => p.IdUsuario == id)
                .Select(p => p.IdProjeto)
                .ToListAsync();

            return await _dbcontext.Projeto.Where(p => idsProjetos.Contains(p.Id))
                .Include(p => p.ProjetoAvaliacaoPublicas)
                .Include(p => p.ProjetoTags)
                .Include(p => p.UsuarioProjetos)
                    .ThenInclude(up => up.IdUsuarioNavigation)
                        .ThenInclude(u => u.IdImagemNavigation)
                .Include(p => p.IdImagemNavigation)
                .ToListAsync();
        }
        public async Task<List<Projeto>> GetAllByFilterAsync(FiltroEnum tipoFiltro, string? filtro, OrdenaEnum tipoOrdenacao, string? ano)
        {
            var projetos = await _dbcontext.Projeto
                .Include(p => p.ProjetoAvaliacaoPublicas)
                .Include(p => p.ProjetoTags)
                .Include(p => p.UsuarioProjetos)
                    .ThenInclude(up => up.IdUsuarioNavigation)
                        .ThenInclude(u => u.IdImagemNavigation)
                .Include(p => p.IdImagemNavigation)
                .Where(p => p.Aprovado == true)
                .ToListAsync();

            foreach (var projeto in projetos)
            {
                projeto.UsuarioProjetos = projeto.UsuarioProjetos
                    .Where(up => up.Estado == ConviteEnum.Aceito)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(ano))
            {
                projetos = projetos
                    .Where(p => p.DataFim.HasValue && p.DataFim.Value.Year.ToString() == ano)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(filtro))
            {
                var padrao = RemoveAccents(filtro.ToLower());

                switch (tipoFiltro)
                {
                    case FiltroEnum.NomeUsuario:
                        projetos = FiltraPorNomeUsuario(projetos, padrao);
                        break;

                    case FiltroEnum.NomeProjeto:
                        projetos = FiltraPorNomeProjeto(projetos, padrao);
                        break;

                    case FiltroEnum.Tag:
                        projetos = FiltraPorTag(projetos, padrao);
                        break;

                    default:
                        throw new Exception("Tipo de Filtro Incorreto");
                }
            }

            switch (tipoOrdenacao)
            {
                case OrdenaEnum.MaisAvaliados:
                    projetos = projetos.OrderByDescending(p => p.ProjetoAvaliacaoPublicas.Count()).ToList();
                    break;

                case OrdenaEnum.MenosAvaliados:
                    projetos = projetos.OrderBy(p => p.ProjetoAvaliacaoPublicas.Count()).ToList();
                    break;

                case OrdenaEnum.Recentes:
                    projetos = projetos.OrderByDescending(p => p.DataFim).ToList();
                    break;

                case OrdenaEnum.Antigos:
                    projetos = projetos.OrderBy(p => p.DataFim).ToList();
                    break;

                default:
                    throw new Exception("Tipo de Ordenação Incorreto");
            }

            return projetos;
        }

        public async Task<List<Projeto>> GetAllActiveByUserAsync(int id)
        {
            var idsProjetos = (await _usuarioProjetoRepository.GetAllByUserId(id)).Where(p => p.AdicionadoEm != null).Select(p => p.IdProjeto);

            return await _dbcontext.Projeto
                .Where(p => idsProjetos.Contains(p.Id) && p.Estado != Core.Enums.StatusProjeto.Canceled && p.Estado != StatusProjeto.Finished)
                .Include(p => p.ProjetoTags)
                .Include(p => p.UsuarioProjetos)
                .ThenInclude(up => up.IdUsuarioNavigation)
                .Include(c => c.IdImagemNavigation)
                .ToListAsync();
        }
        public async Task<List<Projeto>> GetAllByCourse(int idCurso)
        {
            var projetoIdsDoCurso = await _dbcontext.UsuarioProjeto
            .Join(_dbcontext.Usuario,
                up => up.IdUsuario,
                u => u.Id,
                (up, u) => new { up.IdProjeto, u.IdCurso })
            .Where(x => x.IdCurso == idCurso)
            .Select(x => x.IdProjeto)
            .Distinct()
            .ToListAsync();

            return await _dbcontext.Projeto
                .Where(p => projetoIdsDoCurso.Contains(p.Id))
                .Where(p => p.Estado != Core.Enums.StatusProjeto.Canceled && p.Estado != StatusProjeto.Finished)
                .Include(p => p.ProjetoTags)
                .Include(p => p.UsuarioProjetos)
                .ThenInclude(up => up.IdUsuarioNavigation)
                .Include(c => c.IdImagemNavigation)
                .ToListAsync();
        }
        public async Task<Projeto> GetById(int id)
        {
            return await _dbcontext.Projeto.Include(p => p.ProjetoTags).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Projeto> GetDetailsByIdAsync(int id)
        {
            return await _dbcontext.Projeto
                .Include(p => p.ProjetoTags)
                .Include(p => p.UsuarioProjetos)
                .ThenInclude(up => up.IdUsuarioNavigation)
                .Include(c => c.IdImagemNavigation)
                .SingleOrDefaultAsync(p => p.Id == id);
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

        private List<Projeto> FiltraPorNomeUsuario(List<Projeto> projetos, string padrao)
        {
            return (from p in projetos
                    join up in _dbcontext.UsuarioProjeto on p.Id equals up.IdProjeto
                    join u in _dbcontext.Usuario on up.IdUsuario equals u.Id
                    where RemoveAccents(u.Nome.ToLower()).Contains(padrao)
                    select p).ToList();
        }

        private List<Projeto> FiltraPorNomeProjeto(List<Projeto> projetos, string filtro)
        {
            return projetos.Where(p => RemoveAccents(p.Nome.ToLower()).Contains(RemoveAccents(filtro.ToLower()))).ToList();
        }

        private List<Projeto> FiltraPorTag(List<Projeto> projetos, string padrao)
        {
            return (from p in projetos
                    join pt in _dbcontext.ProjetoTag on p.Id equals pt.IdProjeto
                    where RemoveAccents(pt.Nome.ToLower()).Contains(padrao)
                    select p).ToList();
        }

        public static string RemoveAccents(string input)
        {
            return new string(input
                .Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray())
                .Normalize(NormalizationForm.FormC);
        }
    }
}