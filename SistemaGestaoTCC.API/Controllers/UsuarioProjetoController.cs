﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.UsuariosProjeto.RemoverUsuarioProjeto;
using SistemaGestaoTCC.Application.Commands.UsuariosProjeto;
using SistemaGestaoTCC.Application.Queries.UsuariosProjeto;
using SistemaGestaoTCC.Application.Commands.UsuariosProjeto.ResponderConviteProjeto;
using SistemaGestaoTCC.Application.Commands.UsuariosProjeto.GetInvitesByUserId;

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
        [HttpGet("{id}")]
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
        [HttpGet("convitesUsuario/{idUsuario}")]
        public async Task<IActionResult> GetInvitesByUserId(int idUsuario)
        {
            var query = new GetInvitesByUserIdCommand(idUsuario);

            var user = await _mediator.Send(query);

            return Ok(user);
        }
        [HttpPost("responderConviteProjeto")]
        public async Task<IActionResult> Post([FromBody] ResponderConviteProjetoCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }
        [HttpPost("adicionarUsuarioNoProjeto")]
        public async Task<IActionResult> Post([FromBody] AddUserInProjectCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpDelete("removerUsuarioDeProjeto")]
        public async Task<IActionResult> RemoverUsuarioProjeto(RemoveUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
