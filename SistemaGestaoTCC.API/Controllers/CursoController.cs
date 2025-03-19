using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Comentarios.Delete;
using SistemaGestaoTCC.Application.Commands.Courses.CreateCourse;
using SistemaGestaoTCC.Application.Commands.Courses.UpdateCourse;
using SistemaGestaoTCC.Application.Commands.Courses.UpdateImage;
using SistemaGestaoTCC.Application.Queries.Courses.GetAllCourse;
using SistemaGestaoTCC.Application.Queries.Courses.GetCourseById;
using SistemaGestaoTCC.Core.Interfaces;


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
        public async Task<IActionResult> Update([FromBody] UpdateCourseCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/deletarCurso")]
        public async Task<IActionResult> Delete(DeleteCourseCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}