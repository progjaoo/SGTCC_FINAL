using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.AtividadesComentários.Create;
using SistemaGestaoTcc.Application.Commands.AtividadesComentários.Delete;
using SistemaGestaoTcc.Application.Commands.AtividadesComentários.Update;
using SistemaGestaoTcc.Application.Commands.Bancas.Create;
using SistemaGestaoTcc.Application.Commands.Bancas.Delete;
using SistemaGestaoTcc.Application.Commands.Bancas.Update;
using SistemaGestaoTcc.Application.Queries.AtividadesComentários.GetAll;
using SistemaGestaoTcc.Application.Queries.AtividadesComentários.GetById;
using SistemaGestaoTcc.Application.Queries.Bancas.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/atividadeComentarios")]
    public class AtividadeComentarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AtividadeComentarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllAtividadeComentarioQuery();

            var atividade = await _mediator.Send(query);

            return Ok(atividade);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAtividadeComentarioByIdQuery(id);

            var atividade = await _mediator.Send(query);

            if (atividade == null)
            {
                return NotFound();
            }
            return Ok(atividade);
        }
        [HttpPost("criarComentarioAtividade")]
        public async Task<IActionResult> Post([FromBody] CreateAtividadeComentCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarComentarioAtividade")]
        public async Task<IActionResult> Update([FromBody] UpdateAtividadeComentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarComentarioAtividade")]
        public async Task<IActionResult> Delete(DeleteAtividadeComentCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
