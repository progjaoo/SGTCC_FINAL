using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Seminarios.CreateSeminarios;
using SistemaGestaoTCC.Application.Commands.Seminarios.DeleteSeminarios;
using SistemaGestaoTCC.Application.Commands.Seminarios.UpdateSeminarios;
using SistemaGestaoTCC.Application.Queries.Seminarios.GetAllSeminarios;
using SistemaGestaoTCC.Application.Queries.Seminarios.GetAllSeminariosByProjectId;
using SistemaGestaoTCC.Application.Queries.Seminarios.GetSeminariosById;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/seminario")]
    public class SeminarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeminarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllSeminariosQuery();

            var seminario = await _mediator.Send(query);

            return Ok(seminario);
        }
        [HttpGet("todosPorIdProjeto/{idProjeto}")]
        public async Task<IActionResult> GetAllAsync(int idProjeto)
        {
            var query = new GetAllSeminariosByProjectIdQuery
            {
                Id = idProjeto
            };

            var seminario = await _mediator.Send(query);

            return Ok(seminario);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetSeminarioByIdQuery(id);

            var seminario = await _mediator.Send(query);

            if (seminario == null)
            {
                return NotFound();
            }
            return Ok(seminario);
        }
        [HttpPost("criarSeminario")]
        public async Task<IActionResult> PostSeminario([FromBody] CreateSeminarioCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarSeminario")]
        public async Task<IActionResult> Update([FromBody] UpdateSeminarioCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("finalizarSeminario")]
        public async Task<IActionResult> FinalizarSeminario(int id)
        {
            var command = new DeleteSeminarioCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
