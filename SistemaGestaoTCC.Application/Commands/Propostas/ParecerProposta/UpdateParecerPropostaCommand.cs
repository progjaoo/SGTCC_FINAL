using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.Propostas.ParecerProposta
{
    public class UpdateParecerPropostaCommand : IRequest<bool> 
    {
        public int Id { get; }
        public ParecerPropostaEnum NovoParecer { get; }

        public UpdateParecerPropostaCommand(int id, ParecerPropostaEnum novoParecer)
        {
            Id = id;
            NovoParecer = novoParecer;
        }
    }
}
