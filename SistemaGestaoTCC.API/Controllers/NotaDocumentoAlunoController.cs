using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.NotaDocumentos.Create;
using SistemaGestaoTcc.Application.Commands.NotaDocumentos.Delete;
using SistemaGestaoTcc.Application.Commands.NotaDocumentos.Update;
using SistemaGestaoTcc.Application.Queries.NotaDocumentos.GetAll;
using SistemaGestaoTcc.Application.Queries.NotaDocumentos.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/notaDocumentoAluno")]
    [ApiController]
    public class NotaDocumentoAlunoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotaDocumentoAlunoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllNotasDocumentosQuery();
            if (query == null)
                return NotFound();

            var notas = await _mediator.Send(query);

            return Ok(notas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var queryId = new GetNotaDocumentoByIdQuery(id);

            if (queryId == null)
                return NotFound();

            var nota = await _mediator.Send(queryId);

            return Ok(nota);
        }
        [HttpPost("criarNotaDocumento")]
        public async Task<IActionResult> Post([FromBody] CreateNotaDocCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("{id}/atualizarNotaDocumento")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateNotaDocAlunoCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}/deletarNotaDocumento")]
        public async Task<IActionResult> Delete(DeleteNotaDocAlunoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}