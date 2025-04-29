using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Anotacoes.Create;
using SistemaGestaoTCC.Application.Commands.Anotacoes.Delete;
using SistemaGestaoTCC.Application.Commands.Anotacoes.Update;
using SistemaGestaoTCC.Application.Queries.Anotacoes.GetAll;
using SistemaGestaoTCC.Application.Queries.Anotacoes.GetById;
using SistemaGestaoTCC.Application.Queries.Anotacoes.GetByProject;
using SistemaGestaoTCC.Application.Queries.Anotacoes.GetByTitulo;
using SistemaGestaoTCC.Application.Queries.Anotacoes.GetByUser;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/anotacoes")]
    public class AnotacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnotacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("buscarPorTitulo")]
        public async Task<IActionResult> GetByTitulo([FromQuery] string titulo, [FromQuery] int idProjeto)
        {
            var query = new GetAnotacoesByTituloQuery(titulo, idProjeto);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllAnotacaoQuery = new GetAllAnotacoesQuery();

            var anotacao = await _mediator.Send(getAllAnotacaoQuery);

            return Ok(anotacao);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAnotacaoByIdQuery(id);

            var anotacao = await _mediator.Send(query);

            if (anotacao == null)
            {
                return NotFound();
            }
            return Ok(anotacao);
        }
        [HttpGet("buscarPorProjeto")]
        public async Task<IActionResult> GetAnotacaoByProject(int id)
        {
            var query = new GetAnotacaoByProjectQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpGet("buscarPorUsuario/{id}")]
        public async Task<IActionResult> GetAnotacaoByUser(int id)
        {
            var query = new GetAnotacaoByUserQuery(id);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpPost("criarAnotacao")]
        public async Task<IActionResult> Post([FromBody] CreateAnotacaoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarAnotacao")]
        public async Task<IActionResult> Update([FromBody] UpdateAnotacaoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarAnotacao")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAnotacaoCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
