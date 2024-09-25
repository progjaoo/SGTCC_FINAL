using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.ProjetoAtividades.Create;
using SistemaGestaoTcc.Application.Commands.ProjetoAtividades.Delete;
using SistemaGestaoTcc.Application.Commands.ProjetoAtividades.Update;
using SistemaGestaoTcc.Application.Queries.ProjetoAtividades.GetAllAsync;
using SistemaGestaoTcc.Application.Queries.ProjetoAtividades.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/atividades")]
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
        public async Task<IActionResult> Delete(DeleteProjetoAtividadeCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
