using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly SGTCCContext _dbcontext;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(IAuthService authService,SGTCCContext dbcontext)
        {
            _dbcontext = dbcontext;
            _authService = authService;
            _dbcontext = dbcontext;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);
            //instancia do novo usuario pediu 2 construtores la na classe 
            var user = new Usuario(request.IdCurso, request.Nome, request.Email, passwordHash, request.Papel);

            await _dbcontext.Usuario.AddAsync(user);
            await _dbcontext.SaveChangesAsync();

            return user.Id;
        }
    }
}
