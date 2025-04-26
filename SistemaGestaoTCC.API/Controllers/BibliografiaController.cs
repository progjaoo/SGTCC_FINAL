using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Bibliografias.Create;
using SistemaGestaoTCC.Application.Commands.Bibliografias.Delete;
using SistemaGestaoTCC.Application.Commands.Bibliografias.Update;
using SistemaGestaoTCC.Application.Queries.Bibliografia.GetAll;
using SistemaGestaoTCC.Application.Queries.Bibliografia.GetBibliografiaByProject;
using SistemaGestaoTCC.Application.Queries.Bibliografia.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/bibligrafia")]
    public class BibliografiaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BibliografiaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllBibliografias = new GetAllBibliografiaQuery();

            var bibliografia = await _mediator.Send(getAllBibliografias);

            return Ok(bibliografia);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBibliografiaByIdQuery(id);

            var bibliografia = await _mediator.Send(query);

            if (bibliografia == null)
            {
                return NotFound();
            }
            return Ok(bibliografia);
        }
        [HttpGet("bibliografiaPorProjeto")]
        public async Task<IActionResult> GetBibliografiaByProject(int idProjeto)
        {
            var query = new GetBibliografiaByProjectQuery(idProjeto);

            var bibliografia = await _mediator.Send(query);

            if (bibliografia == null)
            {
                return NotFound();
            }
            return Ok(bibliografia);
        }
        [HttpPost("criarBibliografia")]
        public async Task<IActionResult> Post([FromBody] CreateBibliografiaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarBibliografia")]
        public async Task<IActionResult> Update([FromBody] UpdateBibliografiaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarBibliografia")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBibliografiaCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
