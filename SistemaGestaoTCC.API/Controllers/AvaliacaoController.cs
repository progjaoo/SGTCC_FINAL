using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Avaliacoes;
using SistemaGestaoTCC.Application.Queries.Avaliacoes.GetAvaliacaoByProject;
using SistemaGestaoTCC.Application.Queries.Avaliacoes.GetAvaliacaoByUser;
using SistemaGestaoTCC.Application.Queries.Avaliacoes.GetById;

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
        [HttpGet("porUsuario/{idUsuario}")]
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
        [HttpGet("porProjeto/{idProjeto}")]
        public async Task<IActionResult> GetAvaliacoesByProjeto(int idProjeto)
        {
            var query = new GetAvaliacoesByProjectQuery(idProjeto);
            var result = await _mediator.Send(query);

            if (result == null || result.Count == 0)
            {
                return NotFound("Nenhuma avaliação encontrada para o projeto.");
            }

            return Ok(result);
        }
    }
}
