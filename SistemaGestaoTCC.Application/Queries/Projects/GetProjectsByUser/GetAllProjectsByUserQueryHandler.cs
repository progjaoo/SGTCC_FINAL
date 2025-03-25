using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;
namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUser
{
    public class GetAllProjectsQueryByUserHandler : IRequestHandler<GetProjectByUserQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryByUserHandler(IProjectRepository projetoRepository)
        {
            _projectRepository = projetoRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectByUserQuery request, CancellationToken cancellationToken)
        {

            var projeto = await _projectRepository.GetAllByUserAsync(request.IdUsuario);

            var projectViewModel = projeto
                .Select(p => new ProjectViewModel(p.Id, p.Nome, p.Descricao, p.ProjetoTags, p.DataFim))
                .ToList();

            return projectViewModel;
        }
    }
}