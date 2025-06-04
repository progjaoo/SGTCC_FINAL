using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.AvaliadorBancas.Create;
using SistemaGestaoTCC.Application.Commands.AvaliadorBancas.Delete;
using SistemaGestaoTCC.Application.Commands.AvaliadorBancas.Update;
using SistemaGestaoTCC.Application.Queries.AvaliadorBancas.GetAll;
using SistemaGestaoTCC.Application.Queries.AvaliadorBancas.GetByBanca;
using SistemaGestaoTCC.Application.Queries.AvaliadorBancas.GetById;
using SistemaGestaoTCC.Application.Queries.AvaliadorBancas.GetProfessores;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/avaliadorBanca")]
    [ApiController]
    public class AvaliadoresBancaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AvaliadoresBancaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("BuscarProfessores")]
        public async Task<IActionResult> GetProfessores()
        {
            var query = new GetProfessoresQuery();
            var professores = await _mediator.Send(query);
            return Ok(professores);
        }
        [HttpGet("BuscarTodos")]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllAvaliadorBancaQuery();

            if (query == null)
                return NotFound();

            var avaliadorBanca = await _mediator.Send(query);

            return Ok(avaliadorBanca);
        }
        [HttpGet("BuscarTodosPorBanca/{idBanca}")]
        public async Task<IActionResult> GetAllByBancaAsync(int idBanca)
        {
            var query = new GetAvaliadorBancaByBancaIdQuery(idBanca);

            if (query == null)
                return NotFound();

            var avaliadorBanca = await _mediator.Send(query);

            return Ok(avaliadorBanca);
        }
        [HttpGet("{id}/buscarPorId")]
        public async Task<IActionResult> GetById(int id)
        {
            var queryId = new GetAvaliadorBancaByIdQuery(id);

            var avaliadorBanca = await _mediator.Send(queryId);

            if (avaliadorBanca == null)
            {
                return NotFound();
            }
            return Ok(avaliadorBanca);
        }
        [HttpPost("CriarAvaliador")]
        public async Task<IActionResult> Post([FromBody] CreateAvaliadorBancaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarBanca")]
        public async Task<IActionResult> Update([FromBody] UpdateAvaliadorBancaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarBanca")]
        public async Task<IActionResult> Delete(DeleteAvaliadorBancaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }

}
