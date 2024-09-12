using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.CamposDocumento.Create;
using SistemaGestaoTcc.Application.Commands.CamposDocumento.Delete;
using SistemaGestaoTcc.Application.Commands.CamposDocumento.Update;
using SistemaGestaoTcc.Application.Queries.CamposDocumento.GetAll;
using SistemaGestaoTcc.Application.Queries.CamposDocumento.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/campoDocumentoAvaliacao")]
    [ApiController]
    public class CampoDocumentoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CampoDocumentoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllCampoQuery = new GetAllCamposQuery();

            var campos = await _mediator.Send(getAllCampoQuery);

            return Ok(campos);
        }
        [HttpGet("{id}/buscarPorId")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCampoByIdQuery(id);

            var campos = await _mediator.Send(query);

            if (campos == null)
            {
                return NotFound();
            }
            return Ok(campos);
        }
        [HttpPost("criarCamposDoc")]
        public async Task<IActionResult> PostCamposDocumento([FromBody] CreateCampoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("{id}/atualizarCampo")]
        public async Task<IActionResult> Update([FromBody] UpdateCampoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarCampo")]
        public async Task<IActionResult> Delete(DeleteCampoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
