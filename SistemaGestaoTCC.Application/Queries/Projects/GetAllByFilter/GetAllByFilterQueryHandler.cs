using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUser
{
    public class GetAllByFilterQueryHandler : IRequestHandler<GetAllByFilterQuery, List<ProjectFilterViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllByFilterQueryHandler(IProjectRepository projetoRepository)
        {
            _projectRepository = projetoRepository;
        }

        public async Task<List<ProjectFilterViewModel>> Handle(GetAllByFilterQuery request, CancellationToken cancellationToken)
        {
            var projeto = await _projectRepository.GetAllByFilterAsync(request.TipoFiltro, request.Filtro, request.TipoOrdenacao, request.Ano);

            var projectViewModel = projeto
                .Select(p => new ProjectFilterViewModel(p.Id, p.Nome, p.Descricao, p.UsuarioProjetos, p.ProjetoTags, p.IdImagemNavigation, p.DataFim))
                .ToList();

            return projectViewModel;
        }
    }
}
