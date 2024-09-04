using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.Projects.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;
        public CreateProjectCommandHandler(IProjectRepository projectRepository, IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _projectRepository = projectRepository;
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Projeto(request.Nome, request.Descricao, request.Justificativa); //PASSAR TAG DPS
            
            project.Start();

            await _projectRepository.AddASync(project);
            await _projectRepository.SaveChangesAsync();

            var usuarioProjeto = new UsuarioProjeto(project.Id, request.IdUsuario);

            await _usuarioProjetoRepository.AddASync(usuarioProjeto);
            await _usuarioProjetoRepository.SaveChangesAsync();

            return project.Id;
        }
    }
}
