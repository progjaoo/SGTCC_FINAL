using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjectsVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsWithUser
{
    public class GetProjectsWithUsersQueryHandler : IRequestHandler<GetProjectsWithUsersQuery, List<ProjectsAndUserViewModel>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;

        public GetProjectsWithUsersQueryHandler(IProjectRepository projectRepository, IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _projectRepository = projectRepository;
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }

        public async Task<List<ProjectsAndUserViewModel>> Handle(GetProjectsWithUsersQuery request, CancellationToken cancellationToken)
        {
            var projetos = await _projectRepository.GetAllAsync();

            var projectsWithUsers = new List<ProjectsAndUserViewModel>();

            foreach (var projeto in projetos)
            {
                var usuarios = await _usuarioProjetoRepository.GetAllByProjectId(projeto.Id);

                var projectViewModel = new ProjectsAndUserViewModel(
                    projeto.Id,
                    projeto.Nome,
                    projeto.Descricao,
                    projeto.DataFim,
                    projeto.Justificativa,
                    projeto.ProjetoTags,
                    usuarios,
                    projeto.IdImagemNavigation
                );

                projectsWithUsers.Add(projectViewModel);
            }

            return projectsWithUsers;
        }
    }
}
