﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaGestaoTCC.Application.Commands.Users.CreateUser;
using SistemaGestaoTCC.Application.Commands.Users.DeleteUser;
using SistemaGestaoTCC.Application.Commands.Users.LoginGoogle;
using SistemaGestaoTCC.Application.Commands.Users.LoginUser;
using SistemaGestaoTCC.Application.Commands.Users.UpdateUser;
using SistemaGestaoTCC.Application.Commands.Users.UpdateUserImage;
using SistemaGestaoTCC.Application.Queries.Users.DefinirCurso;
using SistemaGestaoTCC.Application.Queries.Users.FindUsers;
using SistemaGestaoTCC.Application.Queries.Users.GetAllNoFilterByProject;
using SistemaGestaoTCC.Application.Queries.Users.GetAllUserByRole;
using SistemaGestaoTCC.Application.Queries.Users.GetAllUsersByCourse;
using SistemaGestaoTCC.Application.Queries.Users.GetUser;
using SistemaGestaoTCC.Application.Queries.Users.GetUserByEmail;
using SistemaGestaoTCC.Core.Enums;
using System.IdentityModel.Tokens.Jwt;

namespace SistemaGestaoTCC.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    //[Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string folderName;

        public UsuarioController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            folderName = configuration["Files:Directory"] ?? "UploadedFiles";
        }


        [HttpGet("encontrarUsuarios")]
        public async Task<IActionResult> FindUsers([FromQuery] FindUsersQuery query)
        {
            //TODO mudar pesquisa para e-mail
            if (query.Papel != Core.Enums.PapelEnum.Aluno && query.Papel != PapelEnum.Professor)
            {
                return BadRequest("Papel inválido");
            }
            var listUsersRole = await _mediator.Send(query);

            return Ok(listUsersRole);
        }
        [HttpGet("usuarioPorPapel")]
        public async Task<IActionResult> GetAllByRole(PapelEnum papel)
        {
            var getAllUserByRole = new GetAllUserByRoleQuery(papel);
            var listUsersRole = await _mediator.Send(getAllUserByRole);

            return Ok(listUsersRole);
        }
        [HttpGet("usuarioPorCurso")]
        public async Task<IActionResult> GetAllUserByCourse(int id)
        {
            var getAllByCourse = new GetAllByCourseQuery(id);

            var listUsers = await _mediator.Send(getAllByCourse);

            return Ok(listUsers);
        }
        [HttpGet("{id}/usuarioPorProjeto")]
        public async Task<IActionResult> GetAllUserByProject(int id)
        {
            var getAllByProject = new GetAllByProjectQuery(id);

            var listUsers = await _mediator.Send(getAllByProject);

            return Ok(listUsers);
        }
        [HttpGet("{id}/usuarioPorProjeto/semFiltro")]
        public async Task<IActionResult> getAllUserNoFilterByProject(int id)
        {
            var getAllByProject = new GetAllNoFilterByProjectQuery(id);

            var listUsers = await _mediator.Send(getAllByProject);

            return Ok(listUsers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserQuery(id);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }
            Console.WriteLine($"Controller: Usuário {user.Nome} - Curso: {user.NomeCurso}");

            return Ok(user);
        }
        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var query = new GetUserByEmailQuery(email);

            var user = await _mediator.Send(query);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("criarUsuario")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpPost("alterarImagem")]
        public async Task<IActionResult> AlterarImagem(int idUsuario, IFormFile file)
        {
            var command = new UpdateUserImageCommand
            {
                Id = idUsuario,
                File = file,
                FolderName = folderName,
            };
            var id = await _mediator.Send(command);

            return Ok("Imagem Alterada");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var loginUser = await _mediator.Send(command);

                if (loginUser == null)
                {
                    return Unauthorized();
                }

                return Ok(loginUser);
            }
            catch (Exception)
            {
                return BadRequest("Conta não Verificada!");
            }

        }
        [HttpPost("authGoogle")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginGoogle([FromBody] string googleToken)
        {
            try
            {
                var command = new AuthGoogleCommand(googleToken);
                var token = await _mediator.Send(command);

                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Erro ao autenticar com o Google: " + ex.Message });
            }
        }
        public static async Task<string> DecodeGoogleToken(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    throw new UnauthorizedAccessException("Token inválido.");

                var emailClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "email");
                if (emailClaim == null)
                    throw new UnauthorizedAccessException("Email não encontrado no token.");

                return emailClaim.Value;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao decodificar token JWT: " + ex.Message);
            }
        }
        [HttpPut("atualizarUsuario")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPost("definir-curso")]
        public async Task<IActionResult> DefinirCurso([FromBody] DefinirCursoCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}/deletarUsuario")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}