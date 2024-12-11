using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Create;
using SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Delete;
using SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Update;
using SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetAllAsync;
using SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/atividade")]
    [ApiController]
    public class ProjetoAtividadeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjetoAtividadeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllAtividadesQuery = new GetAllAtividadesQuery();

            var atividade = await _mediator.Send(getAllAtividadesQuery);

            return Ok(atividade);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAtividadeByIdQuery(id);

            var atividade = await _mediator.Send(query);

            if (atividade == null)
            {
                return NotFound();
            }
            return Ok(atividade);
        }
        [HttpPost("criarAtividade")]
        public async Task<IActionResult> PostCourse([FromBody] CreateProjetoAtividadeCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarAtividade")]
        public async Task<IActionResult> Update([FromBody] UpdateProjetoAtividadeCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarAtividades")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjetoAtividadeCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
