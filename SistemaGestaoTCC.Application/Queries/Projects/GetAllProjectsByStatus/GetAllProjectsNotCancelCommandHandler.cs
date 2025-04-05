using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Application.ViewModels.ProjectsVM;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetAllProjectsByStatus
{
    public class GetAllProjectsNotCancelCommandHandler : IRequestHandler<GetAllProjectsNotCancelCommand, List<ProjectNotCancelViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsNotCancelCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectNotCancelViewModel>> Handle(GetAllProjectsNotCancelCommand request, CancellationToken cancellationToken)
        {
            var projeto = await _projectRepository.GetAllActiveByUserAsync(request.IdUsuario);

            var projectViewModel = projeto
                .Select(p => new ProjectNotCancelViewModel(p.Id, p.Nome, p.Descricao, p.ProjetoTags, p.DataFim, p.IdImagemNavigation))
                .ToList();

            return projectViewModel;

        }
    }
}
