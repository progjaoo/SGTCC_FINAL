using MediatR;

namespace SistemaGestaoTcc.Application.Commands.NotasFinalAluno.Delete
{
    public class DeleteNotaFinalCommand : IRequest<Unit>
    {
        public DeleteNotaFinalCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}