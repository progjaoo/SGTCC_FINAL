using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Create;
using SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Delete;
using SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Finalizar;
using SistemaGestaoTCC.Application.Commands.ProjetoAtividades.IniciarAtividade;
using SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Update;
using SistemaGestaoTCC.Application.Commands.ProjetoAtividades.UpdateStatus;
using SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetAllAsync;
using SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetAtividadeByUser;
using SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetById;
using SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByProject;
using SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByProjectNoFilter;
using SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByStatus;
using SistemaGestaoTCC.Core.Enums;

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
        [HttpGet("projetos/{idProjeto}/atividades/semFiltro")]
        public async Task<IActionResult> GetByProjectIdNoFilterAsync(int idProjeto)
        {
            try
            {
                var atividades = await _mediator.Send(new GetByProjectIdNoFilterQuery(idProjeto));
                return Ok(atividades);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Erro ao buscar atividades: {ex.Message}" });
            }
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
        [HttpGet("projetos/{idProjeto}/atividades")]
        public async Task<IActionResult> GetAtividadesByProjeto(int idProjeto)
        {
            try
            {
                var atividades = await _mediator.Send(new GetAtividadeByProjectQuery(idProjeto));
                return Ok(atividades);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Erro ao buscar atividades: {ex.Message}" });
            }
        }
        [HttpGet("projetos/{idUsuario}/atividadesPorUsuario")]
        public async Task<IActionResult> GetAtividadesByUser(int idUsuario)
        {
            try
            {
                var atividades = await _mediator.Send(new GetAtividadeByUserQuery(idUsuario));
                return Ok(atividades);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Erro ao buscar atividades: {ex.Message}" });
            }
        }
        [HttpGet("atividadesEstado")]
        public async Task<IActionResult> GetAtividadesByStatus(ProjetoAtividadeEnum status, int idProjeto)
        {
            try
            {
                var atividades = await _mediator.Send(new GetAtividadeByStatusQuery(status, idProjeto));
                return Ok(atividades);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = $"Erro ao buscar atividades: {ex.Message}" });
            }
        }
        [HttpPost("criarAtividade")]
        public async Task<IActionResult> Post([FromBody] CreateProjetoAtividadeCommand command)
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
        [HttpPut("{id}/finalizarProjeto")]
        public async Task<IActionResult> Finalizar(int id)
        {
            var command = new FinalizarAtividadeCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPut("iniciarAtividade/{id}")]
        public async Task<IActionResult> StartAtividade(int id)
        {
            var result = await _mediator.Send(new StartAtividadeCommand(id));
            if (!result)
                return NotFound("Atividade não encontrada.");

            return Ok("Atividade iniciada com sucesso.");
        }
        [HttpPut("{idAtividade}/status/{novoEstado}")]
        public async Task<IActionResult> AtualizarStatus(int idAtividade, ProjetoAtividadeEnum novoEstado)
        {
            var comando = new AtualizarStatusAtividadeCommand(idAtividade, novoEstado);
            var sucesso = await _mediator.Send(comando);

            if (sucesso)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
