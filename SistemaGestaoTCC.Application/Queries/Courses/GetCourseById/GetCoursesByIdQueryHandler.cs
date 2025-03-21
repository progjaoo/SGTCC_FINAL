using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Courses.GetCourseById
{
    public class GetCoursesByIdQueryHandler : IRequestHandler<GetCoursesByIdQuery, CourseViewModel>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCoursesByIdQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<CourseViewModel> Handle(GetCoursesByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetById(request.Id);

            if (course == null) return null;

            var courseViewModel = new CourseViewModel(
                course.Id,
                course.Nome,
                course.Descricao,
                course.IdImagemNavigation
            );
            return courseViewModel;
        }

    }
}