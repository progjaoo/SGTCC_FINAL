using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetFinishProjectsByName
{
    public class GetAllFInishProjectsQueryHandler : IRequestHandler<GetAllFInishProjectsQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;
        public GetAllFInishProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllFInishProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllPendingByNameAsync(request.Query);

            var projectViewModel = projects.Select(p=> new ProjectViewModel(p.Id, p.Nome, p.Descricao, p.ProjetoTags, p.DataFim)).ToList();

            return projectViewModel;
        }
    }
}
