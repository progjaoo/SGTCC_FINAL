using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UpdateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            //var passwordHash = _authService.ComputeSha256Hash(request.Senha);

<<<<<<< HEAD
            user.Update(request.Nome, request.Email, request.IdCurso);
=======
            user.Update(request.Nome, request.Email);
>>>>>>> 4865eafeceed53e3f2acb96c61f7b259be1902c0

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
