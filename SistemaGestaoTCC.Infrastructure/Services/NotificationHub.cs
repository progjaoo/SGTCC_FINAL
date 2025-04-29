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
            _logger.LogInformation($"[NotificationHub] Registrando usuário: UserId = {userId} | ConnectionId = {Context.ConnectionId}");
            await Groups.AddToGroupAsync(Context.ConnectionId, userId); 
        }
        public async Task SendNotificationToUser(string userId, string message)
        {
            _logger.LogInformation($"Usuário {userId} registrado com a conexão {Context.ConnectionId}"); 
            await Clients.Group(userId).SendAsync("ReceiveNotification", message);
        }
    }
}