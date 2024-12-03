using MediatR;

namespace SistemaGestaoTCC.Application.Commands.UsuariosProjeto.RemoverUsuarioProjeto
{
    public class RemoveUserCommand : IRequest<Unit>
    {
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }

        public RemoveUserCommand(int idUsuario, int idProjeto)
        {
            IdUsuario = idUsuario;
            IdProjeto = idProjeto;
        }
    }
}
