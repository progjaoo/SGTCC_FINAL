using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Comentarios.Delete
{
    public class DeleteCommentCommand : IRequest<Unit>
    {
        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
