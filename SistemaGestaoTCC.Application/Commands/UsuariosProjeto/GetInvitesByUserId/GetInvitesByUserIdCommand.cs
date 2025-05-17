using MediatR;
using SistemaGestaoTCC.Application.ViewModels.UsersVM;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.UsuariosProjeto.GetInvitesByUserId
{
    public class GetInvitesByUserIdCommand : IRequest<List<UsersAndFunctionViewModel>>
    {
        public int IdUsuario { get; set; }

        public GetInvitesByUserIdCommand(int IdUsuario)
        {
            this.IdUsuario = IdUsuario;
        }
    }
}
