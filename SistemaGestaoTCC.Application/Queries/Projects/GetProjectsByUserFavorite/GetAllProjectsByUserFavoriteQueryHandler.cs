using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;
namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUserFavorite
{
    public class GetAllProjectsQueryByUserFavoriteHandler : IRequestHandler<GetProjectByUserFavoriteQuery, List<ProjectFilterViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryByUserFavoriteHandler(IProjectRepository projetoRepository)
        {
            _projectRepository = projetoRepository;
        }

        public async Task<List<ProjectFilterViewModel>> Handle(GetProjectByUserFavoriteQuery request, CancellationToken cancellationToken)
        {

            var projeto = await _projectRepository.GetAllByUserFavoriteAsync(request.IdUsuario);

            var projectViewModel = projeto
                .Select(p => new ProjectFilterViewModel(p.Id, p.Nome, p.Descricao, p.UsuarioProjetos, p.ProjetoTags, p.IdImagemNavigation, p.DataFim))
                .ToList();

            return projectViewModel;
        }
    }
}