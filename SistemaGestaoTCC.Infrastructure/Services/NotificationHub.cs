using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace SistemaGestaoTCC.Infrastructure.Services
{
    public class NotificationHub : Hub
    {
        private readonly ILogger<NotificationHub> _logger;
        public NotificationHub(ILogger<NotificationHub> logger)
        {
            _logger = logger;
        }
        public async Task Register(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId); //para notificações específicas dentro de um grupo,
                                                                        //to usando para adição do user no projeto
        }
        public async Task SendNotification(string message) // para outras notificações, vou usar para notificar tarefas,
                                                           // agendas para todos
        {
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}