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

            //ADD TAG CONFIRMAR
            if(request.Tags != null && request.Tags.Any())
            {
                foreach(var tagViewModel in request.Tags)
                {
                    var tag = new ProjetoTag
                    {
                        Nome = tagViewModel.Nome,
                        IdProjetoNavigation = project
                    };
                    project.ProjetoTags.Add(tag);
                }
            }
            await _projectRepository.AddASync(project);
            await _projectRepository.SaveChangesAsync();

            //POR CAUSA DO USUARIOPROJETO, QND ADICIONA UM PROJET PRECISA
            //PRECISA VERIFICAR SEMPRE QUAL USUARIO QUE TA AUTENTICADO FAZENDO ESSA AÇÃO
            var usuarioProjeto = new UsuarioProjeto(request.IdUsuario, project.Id);

            await _usuarioProjetoRepository.AddASync(usuarioProjeto);
            await _usuarioProjetoRepository.SaveChangesAsync();

            return project.Id;
        }
    }
}
