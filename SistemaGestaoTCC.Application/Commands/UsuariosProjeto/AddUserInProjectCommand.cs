using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.UsuariosProjeto
{
    public class AddUserInProjectCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public FuncaoEnum Funcao { get; set; }
    }
}
