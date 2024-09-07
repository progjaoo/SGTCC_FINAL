using MediatR;
using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.Commands.Avaliacoes
{
    public class CreateAvaliacaoCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public AvaliacaoEnum Avaliacao { get; set; }
    }
}