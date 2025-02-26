using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Projects.CreateProject;
using SistemaGestaoTCC.Application.Commands.Projects.DeleteProject;
using SistemaGestaoTCC.Application.Commands.Projects.FinalizarProjetos;
using SistemaGestaoTCC.Application.Commands.Projects.TornarPublicos;
using SistemaGestaoTCC.Application.Commands.Projects.UpdateProject;
using SistemaGestaoTCC.Application.Commands.ProjetoArquivo.Create;
using SistemaGestaoTCC.Application.Commands.ProjetoArquivo.Delete;
using SistemaGestaoTCC.Application.Queries.Courses.GetAllCourse;
using SistemaGestaoTCC.Application.Queries.Projects.GetAllProjectsByStatus;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjectById;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjects;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUser;
using SistemaGestaoTCC.Application.Queries.Projects.GetProjectsPending;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;


namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/projetos/arquivos")]
    [ApiController]
    public class ProjetoArquivoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IProjectRepository _projectRepository;
        private readonly string folderName;
        public ProjetoArquivoController(IMediator mediator, IProjectRepository projectRepository, IConfiguration configuration)
        {
            _mediator = mediator;
            _projectRepository = projectRepository;
            folderName = configuration["Files:Directory"] ?? "UploadedFiles";
        }

        [HttpGet("{idProjeto}")]
        public async Task<IActionResult> GetAllAsync(int idProjeto)
        {
            var getAllProjectsQuery = new GetProjectQuery();

            var projects = await _mediator.Send(getAllProjectsQuery);

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

        [HttpPost("enviar")]
        public async Task<IActionResult> Post(int idProjeto, IFormFile file)
        {
            var command = new CreateProjetoArquivoCommand{
                IdProjeto = idProjeto,
                File = file,
                FolderName = folderName
            };
            var id = await _mediator.Send(command);
            // return CreatedAtAction();
            return Ok("Arquivo Enviado!");
        }

        [HttpDelete("deletar/{idProjetoArquivo}")]
        public async Task<IActionResult> Delete(int idProjetoArquivo)
        {
            var command = new DeleteProjetoArquivoCommand{
                Id = idProjetoArquivo
            };

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

    }
}
