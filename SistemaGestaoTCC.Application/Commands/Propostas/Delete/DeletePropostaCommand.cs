using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Propostas.Delete
{
    public class DeletePropostaCommand : IRequest<Unit>
    {
        public DeletePropostaCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
