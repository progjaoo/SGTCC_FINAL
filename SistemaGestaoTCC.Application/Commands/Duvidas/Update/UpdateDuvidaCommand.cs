using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.Duvidas.Update
{
    public class UpdateDuvidaCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public int IdProjeto { get; set; }

        public int IdUsuario { get; set; }

        public string Texto { get; set; }

        public VisibilidadeDuvidaEnum Visibilidade { get; set; }

        public RespotaDuvidaEnum Atendida { get; set; }
    }
}
