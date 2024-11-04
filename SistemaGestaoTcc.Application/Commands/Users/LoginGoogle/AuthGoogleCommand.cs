using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Users.LoginGoogle
{
    public class AuthGoogleCommand : IRequest<string>
    {
        public string GoogleToken { get; }

        public AuthGoogleCommand(string googleToken)
        {
            GoogleToken = googleToken;
        }
    }
}
