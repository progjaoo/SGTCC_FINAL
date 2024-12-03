using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.Avaliacoes
{
    public class CreateAvaliacaoCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public AvaliacaoEnum Avaliacao { get; set; }
    }
}