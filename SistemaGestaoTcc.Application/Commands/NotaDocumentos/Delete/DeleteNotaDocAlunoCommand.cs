using MediatR;

namespace SistemaGestaoTcc.Application.Commands.NotaDocumentos.Delete
{
    public class DeleteNotaDocAlunoCommand : IRequest<Unit>
    {
        public DeleteNotaDocAlunoCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
