using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Comentarios.Delete;
using SistemaGestaoTCC.Application.Commands.Courses.CreateCourse;
using SistemaGestaoTCC.Application.Commands.Courses.UpdateCourse;
using SistemaGestaoTCC.Application.Commands.Courses.UpdateImage;
using SistemaGestaoTCC.Application.Queries.Courses.GetAllCourse;
using SistemaGestaoTCC.Application.Queries.Courses.GetByName;
using SistemaGestaoTCC.Application.Queries.Courses.GetCourseById;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;


namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string folderName;
        public CursoController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            folderName = configuration["Files:Directory"] ?? "UploadedFiles";
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllCoursesQuery = new GetAllCoursesQuery();

            var course = await _mediator.Send(getAllCoursesQuery);

            return Ok(course);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCoursesByIdQuery(id);

            var course = await _mediator.Send(query);

            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
        [HttpGet("buscarPorNome/{name}")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByName(string name)
        {
            var query = new GetCoursesByNameQuery(name);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("criarCurso")]
        public async Task<IActionResult> PostCourse([FromBody] CreateCourseCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPost("alterarImagem")]
        public async Task<IActionResult> AlterarImagem(int idCurso, IFormFile file)
        {
            var command = new UpdateCourseImageCommand
            {
                Id = idCurso,
                File = file,
                FolderName = folderName,
            };
            var id = await _mediator.Send(command);

            return Ok("Imagem Alterada");
        }
        
        [HttpPut("atualizarCurso")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/deletarCurso")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCourseCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}