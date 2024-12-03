using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Courses.GetAllCourse
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<CourseViewModel>>
    {
        private readonly ICourseRepository _courseRepository;
        public GetAllCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<CourseViewModel>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetAllAsync();

            var courseViewModel = course
            .Select(c => new CourseViewModel(c.Id, c.Nome, c.Descricao)).ToList();

            return courseViewModel;
        }
    }
}