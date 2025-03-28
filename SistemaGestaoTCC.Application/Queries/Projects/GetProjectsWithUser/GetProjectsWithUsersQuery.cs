using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjectsVM;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsWithUser
{
    public class GetProjectsWithUsersQuery : IRequest<List<ProjectsAndUserViewModel>>
    {
        public GetProjectsWithUsersQuery() { }
    }
}
