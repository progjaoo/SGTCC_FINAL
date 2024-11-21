using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.Comentarios.Create;
using SistemaGestaoTcc.Application.Commands.Comentarios.Delete;
using SistemaGestaoTcc.Application.Commands.Courses.UpdateCourse;
using SistemaGestaoTcc.Application.Queries.Comentarios.GetAll;
using SistemaGestaoTcc.Application.Queries.Comentarios.GetAllComentsByProject;
using SistemaGestaoTcc.Application.Queries.Comentarios.GetById;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/comentariosprojeto")]
    public class ComentariosController : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        private readonly IMediator _mediator;
        public ComentariosController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("buscarComentarios{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var query = new GetComentByIdQuery(id);
            var comment = await _mediator.Send(query);

            if (query == null)
                return NotFound();

            return Ok(comment);
        }
        [HttpGet("buscarTodos")]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = await _mediator.Send(new GetAllComentsQuery());

            if(query == null)
                return BadRequest();

            return Ok(query);
        }
        [HttpGet("comentariosPorProjeto")]
        public async Task<IActionResult> GetAllCommentsByProject(int projetoId)
        {
            var comentarios = await _mediator.Send(new GetAllCommentsByProjectQuery(projetoId));

            if (comentarios == null || !comentarios.Any())
            {
                return NoContent();
            }
            return Ok(comentarios);
        }
        [HttpGet("comentariosPorUsuario")]
        public async Task<IActionResult> GetAllCommentsByUser(int userId)
        {
            var comentarios = await _mediator.Send(new GetAllCommentsByUserQuery(userId));

            if (comentarios == null || !comentarios.Any())
            {
                return NoContent();
            }
            return Ok(comentarios);
        }
        [HttpPost("criarComentario")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentsCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCommentById), new { id = id }, command);
        }
        [HttpPut("{id}/atualizarComentario")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCommentCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}/deletarComentario")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCommentCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
