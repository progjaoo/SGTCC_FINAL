using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Anotacoes.Create;
using SistemaGestaoTCC.Application.Commands.Anotacoes.Delete;
using SistemaGestaoTCC.Application.Commands.Anotacoes.Update;
using SistemaGestaoTCC.Application.Commands.Propostas.Create;
using SistemaGestaoTCC.Application.Commands.Propostas.Delete;
using SistemaGestaoTCC.Application.Commands.Propostas.ParecerProposta;
using SistemaGestaoTCC.Application.Commands.Propostas.Update;
using SistemaGestaoTCC.Application.Queries.Anotacoes.GetAll;
using SistemaGestaoTCC.Application.Queries.Anotacoes.GetById;
using SistemaGestaoTCC.Application.Queries.Propostas.GetAll;
using SistemaGestaoTCC.Application.Queries.Propostas.GetById;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/propostas")]
    public class PropostasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PropostasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllPropostasQuery = new GetAllPropostasQuery();

            var proposta = await _mediator.Send(getAllPropostasQuery);

            return Ok(proposta);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPropostaByIdQuery(id);

            var proposta = await _mediator.Send(query);

            if (proposta == null)
            {
                return NotFound();
            }
            return Ok(proposta);
        }
        [HttpPost("criarProposta")]
        public async Task<IActionResult> Post([FromBody] CreatePropostaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarProposta")]
        public async Task<IActionResult> Update([FromBody] UpdatePropostaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarProposta")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePropostaCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPut("parecer")]
        public async Task<IActionResult> AtualizarParecer(int id, ParecerPropostaEnum parecer) 
        {    
            var command = new UpdateParecerPropostaCommand(id, parecer);
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound(); 
            }
        }
    }
}
