using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Application.ViewModels.ProjectsVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using System.Linq;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetAllProjectsByCourse
{
    public class GetAllProjectsByCourseCommandHandler : IRequestHandler<GetAllProjectsByCourseCommand, List<ProjectNotCancelViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsByCourseCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectNotCancelViewModel>> Handle(GetAllProjectsByCourseCommand request, CancellationToken cancellationToken)
        {
            var projeto = await _projectRepository.GetAllByCourse(request.IdCurso);

            var projectViewModel = projeto
                .Select(p => new ProjectNotCancelViewModel(p.Id, p.Nome, p.Descricao, p.ProjetoTags, p.DataFim, p.IdImagemNavigation, p.PropostaAprovada))
                .ToList();

            return projectViewModel;

        }
    }
}
