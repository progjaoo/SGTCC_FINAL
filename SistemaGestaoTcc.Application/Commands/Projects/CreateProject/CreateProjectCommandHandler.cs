using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;
using SistemaGestaoTcc.Infrastructure.Services;

namespace SistemaGestaoTcc.Application.Commands.Projects.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;

        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly ILogger<CreateProjectCommandHandler> _logger;

        public CreateProjectCommandHandler(IProjectRepository projectRepository,
            IUsuarioProjetoRepository usuarioProjetoRepository,
            IHubContext<NotificationHub> hubContext,
            ILogger<CreateProjectCommandHandler> logger)
        {
            _projectRepository = projectRepository;
            _usuarioProjetoRepository = usuarioProjetoRepository;
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando criação do projeto...");

            var project = new Projeto(request.Nome, request.Descricao, request.Justificativa);
            
            project.Start();

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

            _logger.LogInformation($"Projeto {project.Id} criado com sucesso. Enviando notificação...");

            var usuarioProjeto = new UsuarioProjeto(request.IdUsuario, project.Id, request.Funcao);

            await _usuarioProjetoRepository.AddASync(usuarioProjeto);
            await _usuarioProjetoRepository.SaveChangesAsync();

            var message = $"{request.IdUsuario} você foi adicionado ao projeto {project.Nome}.";
            await _hubContext.Clients.Group(request.IdUsuario.ToString()).SendAsync("ReceiveNotification", message);

            _logger.LogInformation("Notificação enviada com sucesso.");

            return project.Id;
        }
    }
}
