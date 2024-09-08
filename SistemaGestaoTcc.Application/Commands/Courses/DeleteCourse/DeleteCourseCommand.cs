using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Comentarios.Delete
{
    public class DeleteCourseCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
