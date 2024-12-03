using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Courses.CreateCourse
{
    public class CreateCourseCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
