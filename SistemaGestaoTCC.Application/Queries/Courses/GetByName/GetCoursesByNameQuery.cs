using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Courses.GetByName
{
    public class GetCoursesByNameQuery : IRequest<List<CourseViewModel>>
    {
        public string Name { get; set; }

        public GetCoursesByNameQuery(string name)
        {
            Name = name;
        }
    }
}
