using MediatR;

namespace SistemaGestaoTCC.Application.Commands.NotaDocumentos.Delete
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
