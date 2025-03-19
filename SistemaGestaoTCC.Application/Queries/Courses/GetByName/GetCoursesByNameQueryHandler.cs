using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Courses.GetByName
{
    public class GetCoursesByNameQueryHandler : IRequestHandler<GetCoursesByNameQuery, List<CourseViewModel>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCoursesByNameQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<CourseViewModel>> Handle(GetCoursesByNameQuery request, CancellationToken cancellationToken)
        {          
            var curso = await _courseRepository.GetByNameAsync(request.Name);

            var cursoViewModel = curso
                .Select(c => new CourseViewModel(c.Id, c.Nome, c.Descricao))
                .ToList();

            return cursoViewModel;
        }
    }
}
