using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Courses.UpdateCourse
{
    public class UpdateCommentCommand : IRequest<Unit> 
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Comentario { get; set; }
    }
}
