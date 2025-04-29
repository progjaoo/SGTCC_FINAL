using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly SGTCCContext _dbcontext;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(IAuthService authService, SGTCCContext dbcontext)
        {
            _dbcontext = dbcontext;
            _authService = authService;
            _dbcontext = dbcontext;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _dbcontext.Usuario.AnyAsync(u => u.Email == request.Email);
            if (userExists)
            {
                throw new Exception("Email já cadastrado");
            }

            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            var user = new Usuario(request.IdCurso, request.Nome, request.Email, passwordHash, request.Papel);

            await _dbcontext.Usuario.AddAsync(user);
            await _dbcontext.SaveChangesAsync();

            var emailEnviado = await _authService.SendActivationEmailAsync(user.Id, user.Email);
            if (emailEnviado == false)
            {
                throw new Exception("Não foi possivel enviar o email de ativacão");
            }

            return user.Id;
        }
    }
}
