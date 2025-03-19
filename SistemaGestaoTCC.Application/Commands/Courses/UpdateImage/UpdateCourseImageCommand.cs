using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace SistemaGestaoTCC.Application.Commands.Courses.UpdateImage
{
    public class UpdateCourseImageCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required IFormFile File { get; set; }
        public required string FolderName { get; set; }
    }
}
