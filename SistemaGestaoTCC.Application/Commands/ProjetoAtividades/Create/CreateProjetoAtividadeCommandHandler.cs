using MediatR;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Create;
using SistemaGestaoTCC.Core.Exceptions;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using SistemaGestaoTCC.Infrastructure.Services;

public class CreateProjetoAtividadeCommandHandler : IRequestHandler<CreateProjetoAtividadeCommand, int>
{
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
    private readonly ILogger<CreateProjetoAtividadeCommandHandler> _logger;

    public CreateProjetoAtividadeCommandHandler(IHubContext<NotificationHub> hubContext, IProjetoAtividadeRepository projetoAtividadeRepository, 
        ILogger<CreateProjetoAtividadeCommandHandler> logger)
    {
        _projetoAtividadeRepository = projetoAtividadeRepository;
        _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
    }

    public async Task<int> Handle(CreateProjetoAtividadeCommand request, CancellationToken cancellationToken)
    {
        // if (request.DataEntrega.HasValue && request.DataEntrega < DateTime.Now)
        // {
        //     throw new DataEntregaInvalidaException();
        // }

        var atividade = new ProjetoAtividade(
            request.IdProjeto,
            request.Nome,
            request.Descricao,
            request.IdUsuario,
            request.DuracaoEstimada,
            request.Prioridade,
            request.DataInicio,
            request.DataEntrega
        );

        await _projetoAtividadeRepository.AddASync(atividade);
        await _projetoAtividadeRepository.SaveChangesAsync();

        var userId = request.IdUsuario.ToString();
        var message = $"Uma nova atividade \"{atividade.Nome}\" foi atribuída a você!";

        _logger.LogInformation($"Enviando notificação: UserId = {userId}, Message = {message}");

        await _hubContext.Clients.Group(request.IdUsuario.ToString())
            .SendAsync("ReceiveNotification", $"Você tem uma nova atividade \"{atividade.Nome}\"!");

        return atividade.Id;
    }
}