using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Anotacoes.Create;
using SistemaGestaoTCC.Application.Commands.Anotacoes.Delete;
using SistemaGestaoTCC.Application.Commands.Anotacoes.Update;
using SistemaGestaoTCC.Application.Commands.Relatorios.Create;
using SistemaGestaoTCC.Application.Commands.Relatorios.Delete;
using SistemaGestaoTCC.Application.Commands.Relatorios.GerarPdf;
using SistemaGestaoTCC.Application.Commands.Relatorios.Update;
using SistemaGestaoTCC.Application.Queries.Relatorios.GetAll;
using SistemaGestaoTCC.Application.Queries.Relatorios.GetById;
using SistemaGestaoTCC.Application.Queries.Relatorios.GetRelatorioByProject;
using SistemaGestaoTCC.Application.Queries.Relatorios.GetRelatorioByUser;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/relatorios")]
    public class RelatorioAcompanhementoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RelatorioAcompanhementoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllRelatorio = new GetAllRelatorioQuery();

            var relatorios = await _mediator.Send(getAllRelatorio);

            return Ok(relatorios);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetRelatorioByIdQuery(id);

            var relatorios = await _mediator.Send(query);

            if (relatorios == null)
            {
                return NotFound();
            }
            return Ok(relatorios);
        }
        [HttpGet("buscarRelatorioPorUsuario")]
        public async Task<IActionResult> GetRelatorioByUser(int idUsuario)
        {
            var query = new GetRelatorioByUserQuery(idUsuario);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpGet("buscarRelatorioPorProjeto")]
        public async Task<IActionResult> GetRelatorioByProject(int idProjeto)
        {
            var query = new GetRelatorioByProjectQuery(idProjeto);
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpPost("criarRelatorio")]
        public async Task<IActionResult> Post([FromBody] CreateRelatorioCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarRelatorio")]
        public async Task<IActionResult> Update([FromBody] UpdateRelatorioCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("deletarRelatorio")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteRelatorioCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpGet("GerarPdfRelatorio")]
        public async Task<IActionResult> GerarPDFCarteirinha(int idRelatorio)
        {
            var result = await _mediator.Send(new GerarRelatorioPdfCommand(idRelatorio));
            return File(result, "application/pdf", "Relatorio.pdf");
        }
    }
}
