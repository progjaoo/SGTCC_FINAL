using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;

namespace SistemaGestaoTCC.Application.Queries.Courses.GetCourseById
{
    public class GetCoursesByIdQuery : IRequest<CourseViewModel>
    {
        public GetCoursesByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}