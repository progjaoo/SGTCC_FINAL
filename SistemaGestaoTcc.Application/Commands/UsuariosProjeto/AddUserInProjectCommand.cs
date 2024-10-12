using MediatR;
using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.Commands.UsuariosProjeto
{
    public class AddUserInProjectCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public FuncaoEnum Funcao { get; set; }
    }
}
