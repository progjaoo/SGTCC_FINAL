using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Projects.CreateProject;
using SistemaGestaoTCC.Application.Commands.Projects.DeleteProject;
using SistemaGestaoTCC.Application.Commands.Projects.FinalizarProjetos;
using SistemaGestaoTCC.Application.Commands.Projects.TornarPublicos;
using SistemaGestaoTCC.Application.Commands.Projects.UpdateProject;
using SistemaGestaoTCC.Application.Queries.Courses.GetAllCourse;
using SistemaGestaoTCC.Application.Queries.Projects.GetAllProjectsByStatus;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjectById;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjects;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUser;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjectsPending;
using SistemaGestaoTCC.Core.Interfaces;


namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/projetos")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProjectRepository _projectRepository;
        public ProjectsController(IMediator mediator, IProjectRepository projectRepository)
        {
            _mediator = mediator;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllProjectsQuery = new GetProjectQuery();

            var projects = await _mediator.Send(getAllProjectsQuery);

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
        [HttpGet("projetosNaoCancelados/{id}")]
        public async Task<IActionResult> GetAllProjectsNotCancel(int id)
        {
            var getAllProjectQuery = new GetAllProjectsNotCancelCommand(id);
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
        [HttpPut("{id}/atualizarProjeto")]
        // [Authorize(Roles = "Aluno")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            command.Id = id;
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
        public async Task<IActionResult> Finalizar(FinalizarProjectCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPut("{id}/tornarPublico")]
        public async Task<IActionResult> TornarPublico(TornarPublicoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
