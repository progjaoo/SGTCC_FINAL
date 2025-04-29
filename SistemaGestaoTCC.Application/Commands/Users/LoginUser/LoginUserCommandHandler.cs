using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Users.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            var user = await _userRepository.GetByEmailByPassword(request.Email, passwordHash);

            if (user == null)
            {
                return null;
            }
            if (user.EmailVerificado != Core.Enums.EmailVerificadoEnum.Sim) {
                throw new Exception("Usuário nao verificado");
            }

            user.UltimoAcesso = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            var token = _authService.GenerateJwtToken(user.Email, user.Papel.ToString());

            return new LoginUserViewModel(user.Email, token, user.Id, user.IdCurso, user.Papel);
        }
    }
}