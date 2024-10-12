using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.Avaliacoes;
using SistemaGestaoTcc.Application.Queries.Avaliacoes.GetAvaliacaoByUser;
using SistemaGestaoTcc.Application.Queries.Avaliacoes.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/avaliacoes")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AvaliacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("buscarAvaliacao{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAvaliacaoByIdQuery(id);
            var avaliacao = await _mediator.Send(query);

            if (query == null)
                return NotFound();

            return Ok(avaliacao);
        }
        [HttpPost("criarAvaliacao")]
        public async Task<IActionResult> Post([FromBody] CreateAvaliacaoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpGet("usuario/{idUsuario}")]
        public async Task<IActionResult> GetAvaliacoesByUsuario(int idUsuario)
        {
            var query = new GetAvaliacoesByUsuarioQuery(idUsuario);
            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0)
            {
                return NotFound("Nenhuma avaliação encontrada para o usuário.");
            }

            return Ok(result);
        }
    }
}
