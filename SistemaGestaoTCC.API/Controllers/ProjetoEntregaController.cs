using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.ProjetosEntrega.Create;
using SistemaGestaoTcc.Application.Commands.ProjetosEntrega.Delete;
using SistemaGestaoTcc.Application.Commands.ProjetosEntrega.Update;
using SistemaGestaoTcc.Application.Queries.ProjetoEntrega.GetAll;
using SistemaGestaoTcc.Application.Queries.ProjetoEntrega.GetById;
using SistemaGestaoTcc.Application.Queries.ProjetoEntrega.GetEntregaByProject;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/projetoEntrega")]
    public class ProjetoEntregaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjetoEntregaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllProjetoEntregasQuery();

            var entrega = await _mediator.Send(query);

            return Ok(entrega);
        }
        [HttpGet("entregaPorProjeto")]
        public async Task<IActionResult> GetEntregaByProjeto(int idProjeto)
        {
            var queryId = new GetEntregaByProjectQuery(idProjeto);

            var entrega = await _mediator.Send(queryId);

            if (entrega == null || !entrega.Any())
            {
                return NotFound($"Nenhuma entrega encontrada para o projeto com ID {idProjeto}");
            }

            return Ok(entrega);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjetoEntregaByIdQuery(id);

            var entrega = await _mediator.Send(query);

            if (entrega == null)
            {
                return NotFound();
            }
            return Ok(entrega);
        }
        [HttpPost("criarEntrega")]
        public async Task<IActionResult> PostBanca([FromBody] CreateProjetoEntregaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarEntrega")]
        public async Task<IActionResult> Update([FromBody] UpdateProjetoEntregaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarEntrega")]
        public async Task<IActionResult> Delete(DeleteProjetoEntregaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}