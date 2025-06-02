using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Projects.CreateProject;
using SistemaGestaoTCC.Application.Commands.Projects.DeleteProject;
using SistemaGestaoTCC.Application.Commands.Projects.FinalizarProjetos;
using SistemaGestaoTCC.Application.Commands.Projects.TornarPublicos;
using SistemaGestaoTCC.Application.Commands.Projects.UpdateImage;
using SistemaGestaoTCC.Application.Commands.Projects.UpdateProject;
using SistemaGestaoTCC.Application.Queries.Dashboard;
using SistemaGestaoTCC.Application.Queries.Projects.GetAllProjectsByCourse;
using SistemaGestaoTCC.Application.Queries.Projects.GetAllProjectsByStatus;
using SistemaGestaoTCC.Application.Queries.Projects.GetFinishProjectsByName;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjectById;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjects;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUser;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjectsPending;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjectsWithUser;
using SistemaGestaoTCC.Application.ViewModels.ProjectsVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;


namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/projetos")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string folderName;
        public ProjetoController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            folderName = configuration["Files:Directory"] ?? "UploadedFiles";
        }
        [HttpGet("{id}/dashboard")]
        public async Task<IActionResult> GetDashboard(int id)
        {
            var result = await _mediator.Send(new GetDashboardProjetoQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllProjectsQuery = new GetProjectQuery();

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }
        [HttpGet("pendente/porNome")]
        public async Task<IActionResult> GetAllPendingByNameAsync(string nome)
        {
            var getAllProjectQuery = new GetAllFInishProjectsQuery(nome);
            var projects = await _mediator.Send(getAllProjectQuery);
            return Ok(projects);
        }
        [HttpGet("pendente")]
        public async Task<IActionResult> GetAllPendingAsync()
        {
            var getAllProjectQuery = new GetProjectPendingQuery();
            var projects = await _mediator.Send(getAllProjectQuery);

            return Ok(projects);
        }
        [HttpGet("porUsuario/{id}")]
        public async Task<IActionResult> GetAllByUserAsync(int id)
        {
            var getAllProjectQuery = new GetProjectByUserQuery(id);
            var projects = await _mediator.Send(getAllProjectQuery);

            return Ok(projects);
        }
        [HttpGet("filtroGeral")]
        public async Task<IActionResult> GetAllByFilter(FiltroEnum tipoFiltro, string? filtro, OrdenaEnum tipoOrdenacao, string? ano)
        {
            if (string.IsNullOrEmpty(filtro) && string.IsNullOrEmpty(ano))
            {
                return BadRequest("Texto de Filtro e Ano não podem ser nulos ao mesmo tempo. preencha um ou ambos!");
            }

            var getAllProjectQuery = new GetAllByFilterQuery(tipoFiltro, filtro, tipoOrdenacao, ano);
            try
            {
                var projects = await _mediator.Send(getAllProjectQuery);
                return Ok(projects);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("projetosNaoCancelados/{id}")]
        public async Task<IActionResult> GetAllProjectsNotCancel(int id)
        {
            var getAllProjectQuery = new GetAllProjectsNotCancelCommand(id);
            var projects = await _mediator.Send(getAllProjectQuery);

            return Ok(projects);
        }

        [HttpGet("projetosPorCurso/{idCurso}")]
        public async Task<IActionResult> GetAllProjectsByCourse(int idCurso)
        {
            var getAllProjectQuery = new GetAllProjectsByCourseCommand(idCurso);
            var projects = await _mediator.Send(getAllProjectQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }
        //[Authorize(Roles = "Aluno")]
        [HttpPost("criarProjeto")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPost("alterarImagem")]
        public async Task<IActionResult> AlterarImagem(int idProjeto, IFormFile file)
        {
            var command = new UpdateProjectImageCommand
            {
                Id = idProjeto,
                File = file,
                FolderName = folderName,
            };
            var id = await _mediator.Send(command);

            return Ok("Imagem Alterada");
        }
        [HttpPut("{id}/atualizarProjeto")]
        // [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> Put([FromBody] UpdateProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPut("{id}/cancelarProjeto")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPut("{id}/finalizarProjeto")]
        public async Task<IActionResult> Finalizar(int id)
        {
            var command = new FinalizarProjectCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPut("{id}/tornarPublico")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> TornarPublico(int id)
        {
            var command = new TornarPublicoCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpGet("projetosComUsuarios")]
        public async Task<ActionResult<List<ProjectsAndUserViewModel>>> GetProjectsWithUsers()
        {
            try
            {
                var projectsWithUsers = await _mediator.Send(new GetProjectsWithUsersQuery());

                return Ok(projectsWithUsers);
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, new { message = "Ocorreu um erro ao processar a solicitação.", exception = ex.Message });
            }
        }
    }
}