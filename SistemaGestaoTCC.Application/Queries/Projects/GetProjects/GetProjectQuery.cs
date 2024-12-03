using MediatR;
using SistemaGestaoTCC.Application.ViewModels;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjects
{
    public class GetProjectQuery : IRequest<List<ProjectViewModel>>{   }
}
