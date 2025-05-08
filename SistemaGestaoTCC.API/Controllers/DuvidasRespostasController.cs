using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.DuvidasRepostas.Delete;
using SistemaGestaoTCC.Application.Commands.DuvidasRepostas.ResponderDuvida;
using SistemaGestaoTCC.Application.Commands.DuvidasRepostas.Update;
using SistemaGestaoTCC.Application.Queries.Duvidas.GetAll;
using SistemaGestaoTCC.Application.Queries.RespostaDuvidas.GetAll;
using SistemaGestaoTCC.Application.Queries.RespostaDuvidas.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/respostaDuvidas")]
    [ApiController]
    public class DuvidasRespostasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DuvidasRespostasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllRespostaDuvidaQuery();
            var duvidasRespostas = await _mediator.Send(query);
            return Ok(duvidasRespostas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetRespostaDuvidaByIdQuery(id);
            var duvidasRespostas = await _mediator.Send(query);
            if (duvidasRespostas == null)
            {
                return NotFound();
            }
            return Ok(duvidasRespostas);
        }
        [HttpPost("responderDuvida")]
        public async Task<IActionResult> Create([FromBody] ResponderDuvidaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarResposta")]
        public async Task<IActionResult> Update([FromBody] UpdateRespostaDuvidaCommand command)
        {
            await _mediator.Send(command);
            
            return NoContent();
        }
        [HttpDelete("deletarResposta")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteRespostaDuvidaCommand(id);
            
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
