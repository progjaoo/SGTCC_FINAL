using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTcc.Application.Commands.UsuariosProjeto;
using SistemaGestaoTcc.Application.Queries.UsuariosProjeto;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/usuariosProjeto")]
    [ApiController]
    public class UsuarioProjetoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioProjetoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserProjectByIdQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserInProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
    }
}
