namespace SistemaGestaoTCC.Infrastructure.Services
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class NotificacaoBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<NotificacaoBackgroundService> _logger;

        public NotificacaoBackgroundService(IServiceProvider serviceProvider, ILogger<NotificacaoBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var notificacaoService = scope.ServiceProvider.GetRequiredService<INotificacaoService>();

                    try
                    {
                        await notificacaoService.NotificarPrazoEntregaAtividadesAsync();
                        _logger.LogInformation($"[NotificacaoBackgroundService] Execução concluída às {DateTime.Now}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Erro ao executar NotificacaoService");
                    }
                }

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken); 
            }
        }
    }

}
