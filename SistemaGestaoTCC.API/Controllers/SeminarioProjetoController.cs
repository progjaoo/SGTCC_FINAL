using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Seminarios.CreateSeminariosProjeto;
using SistemaGestaoTCC.Application.Commands.Seminarios.DeleteSeminariosProjeto;
using SistemaGestaoTCC.Application.Commands.Seminarios.UpdateSeminariosProjeto;
using SistemaGestaoTCC.Application.Queries.Seminarios.GetAllSeminariosProjetos;
using SistemaGestaoTCC.Application.Queries.Seminarios.GetProjetosBySeminario;
using SistemaGestaoTCC.Application.Queries.Seminarios.GetSeminariosProjetosById;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/seminarioProjeto")]
    public class SeminarioProjetoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeminarioProjetoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllSeminariosProjetosQuery();

            var seminario = await _mediator.Send(query);

            return Ok(seminario);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetSeminariosProjetoByIdQuery(id);

            var seminario = await _mediator.Send(query);

            if (seminario == null)
            {
                return NotFound();
            }
            return Ok(seminario);
        }
        [HttpPost("criarSeminarioProjeto")]
        public async Task<IActionResult> PostSeminario([FromBody] CreateSeminarioProjetoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarSeminarioProjeto")]
        public async Task<IActionResult> Update([FromBody] UpdateSeminarioProjetoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("removerProjetoDoSeminario")]
        public async Task<IActionResult> DeletarSeminario(int idSeminario, int idProjeto)
        {
            var command = new DeleteSeminarioProjetoCommand(idSeminario, idProjeto);
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpGet("{idSeminario}/projetos")]
        public async Task<IActionResult> GetProjetosPorSeminario(int idSeminario)
        {
            try
            {
                var query = new GetProjetosBySeminarioQuery(idSeminario);
                var result = await _mediator.Send(query);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao buscar projetos do seminário: {ex.Message}");
            }
        }
    }
}
