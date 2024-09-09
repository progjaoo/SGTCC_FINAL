using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.Bancas.Create;
using SistemaGestaoTcc.Application.Commands.Bancas.Delete;
using SistemaGestaoTcc.Application.Commands.Bancas.Update;
using SistemaGestaoTcc.Application.Commands.Courses.CreateCourse;
using SistemaGestaoTcc.Application.Commands.Courses.UpdateCourse;
using SistemaGestaoTcc.Application.Queries.Bancas.GetAll;
using SistemaGestaoTcc.Application.Queries.Bancas.GetById;
using SistemaGestaoTcc.Application.Queries.Courses.GetAllCourse;
using SistemaGestaoTcc.Application.Queries.Courses.GetCourseById;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/banca")]
    [ApiController]
    public class BancaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BancaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllBancasQuery();

            var banca = await _mediator.Send(query);

            return Ok(banca);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBancaByIdQuery(id);

            var banca = await _mediator.Send(query);

            if (banca == null)
            {
                return NotFound();
            }
            return Ok(banca);
        }
        [HttpPost("criarBanca")]
        public async Task<IActionResult> PostBanca([FromBody] CreateBancaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarBanca")]
        public async Task<IActionResult> Update([FromBody] UpdateBancaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarBanca")]
        public async Task<IActionResult> Delete(DeleteBancaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
