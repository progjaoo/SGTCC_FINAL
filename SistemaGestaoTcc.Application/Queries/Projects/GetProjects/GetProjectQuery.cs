using MediatR;
using SistemaGestaoTcc.Application.ViewModels;

namespace SistemaGestaoTcc.Application.Queries.Projects.GetProjects
{
    public class GetProjectQuery : IRequest<List<ProjectViewModel>>{   }
}
