using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Duvidas.Create;
using SistemaGestaoTCC.Application.Commands.Duvidas.Delete;
using SistemaGestaoTCC.Application.Commands.Duvidas.Update;
using SistemaGestaoTCC.Application.Queries.Duvidas.GetAll;
using SistemaGestaoTCC.Application.Queries.Duvidas.GetById;
using SistemaGestaoTCC.Application.Queries.Duvidas.GetDuvidaByProject;
using SistemaGestaoTCC.Application.Queries.Duvidas.GetDuvidaByUser;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/duvidas")]
    [ApiController]
    public class DuvidasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DuvidasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllDuvidasQuery();

            var duvidas = await _mediator.Send(query);

            return Ok(duvidas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDuvidaByIdQuery(id);

            var duvidas = await _mediator.Send(query);

            if (duvidas == null)
            {
                return NotFound();
            }
            return Ok(duvidas);
        }
        [HttpGet("duvidasPorProjeto")]
        public async Task<IActionResult> GetDuvidasByProject(int idProjeto)
        {
            var query = new GetDuvidaByProjectQuery(idProjeto);

            var duvidas = await _mediator.Send(query);

            if (duvidas == null)
            {
                return NotFound();
            }
            return Ok(duvidas);
        }
        [HttpGet("duvidasPorUsuario")]
        public async Task<IActionResult> GetDuvidasByUser(int idUsuario)
        {
            var query = new GetDuvidaByUserQuery(idUsuario);

            var duvidas = await _mediator.Send(query);

            if (duvidas == null)
            {
                return NotFound();
            }
            return Ok(duvidas);
        }
        [HttpPost("criarDuvida")]
        public async Task<IActionResult> Post([FromBody] CreateDuvidaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarDuvida")]
        public async Task<IActionResult> Update([FromBody] UpdateDuvidaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("deletarDuvida")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDuvidaCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
