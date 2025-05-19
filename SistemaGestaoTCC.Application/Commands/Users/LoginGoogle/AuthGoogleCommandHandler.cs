using Google.Apis.Auth;
using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Users.LoginGoogle
{
    public class AuthGoogleCommandHandler : IRequestHandler<AuthGoogleCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly SGTCCContext _dbcontext;

        public AuthGoogleCommandHandler(IUserRepository userRepository, IAuthService authService, SGTCCContext dbcontext)
        {
            _userRepository = userRepository;
            _authService = authService;
            _dbcontext = dbcontext;
        }

        public async Task<string> Handle(AuthGoogleCommand request, CancellationToken cancellationToken)
        {
            var googleToken = await GoogleJsonWebSignature.ValidateAsync(request.GoogleToken);

            if (googleToken == null || string.IsNullOrEmpty(googleToken.Email))
                throw new UnauthorizedAccessException("Token do Google inválido.");

            var user = await _userRepository.GetByEmail(googleToken.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Usuário não encontrado ou inativo.");

            var jwtToken = _authService.GenerateJwtToken(user.Email, user.Papel.ToString());

            return jwtToken;
        }
    }

}