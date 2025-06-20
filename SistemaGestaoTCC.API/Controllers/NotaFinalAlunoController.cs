﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.NotasFinalAluno.Create;
using SistemaGestaoTCC.Application.Commands.NotasFinalAluno.Delete;
using SistemaGestaoTCC.Application.Commands.NotasFinalAluno.Update;
using SistemaGestaoTCC.Application.Queries.NotaFinalAluno.GetAll;
using SistemaGestaoTCC.Application.Queries.NotaFinalAluno.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [ApiController]
    [Route("api/notaFinalAluno")]
    public class NotaFinalAlunoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotaFinalAlunoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllNotaFinalQuery();
            if (query == null)
                return NotFound();

            var notas = await _mediator.Send(query);

            return Ok(notas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var queryId = new GetNotaFinalByIdQuery(id);

            if (queryId == null)
                return NotFound();

            var nota = await _mediator.Send(queryId);

            return Ok(nota);
        }
        [HttpPost("criarNotaFinal")]
        public async Task<IActionResult> Post([FromBody] CreateNotaFinalAlunoCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPut("atualizarNotaFinal")]
        public async Task<IActionResult> Put([FromBody] UpdateNotaFinalCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}/deletarNotaFinal")]
        public async Task<IActionResult> Delete(DeleteNotaFinalCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}