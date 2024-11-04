using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Queries.Projects.GetAllProjectsByStatus
{
    public class GetAllProjectsNotCancelCommandHandler : IRequestHandler<GetAllProjectsNotCancelCommand, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsNotCancelCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsNotCancelCommand request, CancellationToken cancellationToken)
        {
            var projeto = await _projectRepository.GetAllActiveByUserAsync(request.IdUsuario);

            var projectViewModel = projeto
                .Select(p => new ProjectViewModel(p.Id, p.Nome, p.Descricao))
                .ToList();

            return projectViewModel;

        }
    }
}
