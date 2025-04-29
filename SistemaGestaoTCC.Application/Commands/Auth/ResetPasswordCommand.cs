using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.Auth.ResetPassword
{
    public class ResetPasswordCommand : IRequest<int>
    {
        public string Token { get; set; }
        public string NovaSenha { get; set; }
    }
}
