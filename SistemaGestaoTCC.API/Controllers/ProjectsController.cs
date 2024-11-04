using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.Projects.CreateProject;
using SistemaGestaoTcc.Application.Commands.Projects.DeleteProject;
using SistemaGestaoTcc.Application.Commands.Projects.FinalizarProjetos;
using SistemaGestaoTcc.Application.Commands.Projects.TornarPublicos;
using SistemaGestaoTcc.Application.Commands.Projects.UpdateProject;
using SistemaGestaoTcc.Application.Queries.Courses.GetAllCourse;
using SistemaGestaoTcc.Application.Queries.Projects.GetAllProjectsByStatus;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjectById;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjects;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjectsByUser;
using SistemaGestaoTcc.Application.Queries.Projects.GetProjectsPending;
using SistemaGestaoTcc.Core.Interfaces;


namespace SistemaGestaoTcc.API.Controllers
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
