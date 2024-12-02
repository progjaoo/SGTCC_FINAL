using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Comentarios.Delete;
using SistemaGestaoTCC.Application.Commands.Courses.CreateCourse;
using SistemaGestaoTCC.Application.Commands.Courses.UpdateCourse;
using SistemaGestaoTCC.Application.Queries.Courses.GetAllCourse;
using SistemaGestaoTCC.Application.Queries.Courses.GetCourseById;
using SistemaGestaoTCC.Core.Interfaces;


namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/cursos")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
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