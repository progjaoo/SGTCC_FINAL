using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Comentarios.Create;
using SistemaGestaoTCC.Application.Commands.Comentarios.Delete;
using SistemaGestaoTCC.Application.Commands.Courses.UpdateCourse;
using SistemaGestaoTCC.Application.Queries.Comentarios.GetAll;
using SistemaGestaoTCC.Application.Queries.Comentarios.GetAllComentsByProject;
using SistemaGestaoTCC.Application.Queries.Comentarios.GetById;

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
        [HttpGet("{id}/buscarComentarios")]
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
        [HttpGet("{id}/comentariosPorProjeto")]
        public async Task<IActionResult> GetAllCommentsByProject(int id)
        {
            var comentarios = await _mediator.Send(new GetAllCommentsByProjectQuery(id));

            if (comentarios == null || !comentarios.Any())
            {
                return NoContent();
            }
            return Ok(comentarios);
        }
        [HttpGet("{id}/comentariosPorUsuario")]
        public async Task<IActionResult> GetAllCommentsByUser(int id)
        {
            var comentarios = await _mediator.Send(new GetAllCommentsByUserQuery(id));

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
        [HttpPut("atualizarComentario")]
        public async Task<IActionResult> Put([FromBody] UpdateCommentCommand command)
        {
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
