using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.ProjetoEntregasProjeto.AddProjetoEntrega;
using SistemaGestaoTCC.Application.Commands.ProjetosEntrega.Create;
using SistemaGestaoTCC.Application.Commands.ProjetosEntrega.Delete;
using SistemaGestaoTCC.Application.Commands.ProjetosEntrega.Update;
using SistemaGestaoTCC.Application.Queries.ProjetoEntrega.GetAll;
using SistemaGestaoTCC.Application.Queries.ProjetoEntrega.GetById;
using SistemaGestaoTCC.Application.Queries.ProjetoEntrega.GetEntregaByProject;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/projetoEntrega")]
    [Authorize(Roles = "Professor")]
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
        public async Task<IActionResult> Post([FromBody] CreateProjetoEntregaCommand command)
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
        [HttpPost("adicionarProjetoEmEntrega")]
        public async Task<IActionResult> AddProjectEmEntrega([FromBody] AddProjetoEmEntregaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpDelete("removerProjetoDaEntrega")]
        public async Task<IActionResult> DeleteProjectEmEntrega([FromBody] DeleteProjetoEntregaCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}