using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Application.ViewModels.ProjectsVM;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetAllProjectsByCourse
{
    public class GetAllProjectsByCourseCommand : IRequest<List<ProjectNotCancelViewModel>>
    {
        public int IdCurso { get; }

        public GetAllProjectsByCourseCommand(int idCurso)
        {
            IdCurso = idCurso;
        }
    }
}