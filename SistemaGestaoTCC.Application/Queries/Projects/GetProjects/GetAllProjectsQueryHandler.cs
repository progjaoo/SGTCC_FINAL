using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;
using System.Linq;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetProjectQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(IProjectRepository projetoRepository)
        {
            _projectRepository = projetoRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {

            var projeto = await _projectRepository.GetAllAsync();

            var projectViewModel = projeto
                .Select(p => new ProjectViewModel(p.Id, p.Nome, p.Descricao, p.DataFim,p.Justificativa, p.ProjetoTags))
                .ToList();

            return projectViewModel;
        }
    }
}
