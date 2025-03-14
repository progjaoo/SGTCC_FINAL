using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.AtividadesComentários.Create;
using SistemaGestaoTCC.Application.Commands.AtividadesComentários.Delete;
using SistemaGestaoTCC.Application.Commands.AtividadesComentários.Update;
using SistemaGestaoTCC.Application.Queries.AtividadesComentários.GetAll;
using SistemaGestaoTCC.Application.Queries.AtividadesComentários.GetById;
using SistemaGestaoTCC.Application.Queries.AtividadesComentários.GetComentByAtividade;
using SistemaGestaoTCC.Core.Interfaces;

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
        [HttpGet("projetoAtividade/{id}/comentarios")]
        public async Task<IActionResult> GetByProjetoAtividadeId(int id)
        {
            var query = new GetAtividadesComentariosByProjetoAtividadeIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound("Nenhum comentário encontrado para essa Atividade.");

            return Ok(result);
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
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAtividadeComentCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
