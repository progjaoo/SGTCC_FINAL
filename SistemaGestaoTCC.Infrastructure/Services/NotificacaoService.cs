using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Infrastructure.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly IProjetoAtividadeRepository _atividadeRepository;
        private readonly IEmailService _emailService;

        public NotificacaoService(
            IProjetoAtividadeRepository atividadeRepository,
            IEmailService emailService)
        {
            _atividadeRepository = atividadeRepository;
            _emailService = emailService;
        }

        public async Task NotificarPrazoEntregaAtividadesAsync()
        {
            var atividades = await _atividadeRepository.GetAllAsync();

            var hoje = DateTime.Today;

            foreach (var atividade in atividades)
            {
                if (!atividade.DataEntrega.HasValue || atividade.Estado == ProjetoAtividadeEnum.Finalizada)
                    continue;

                var diasParaEntrega = (atividade.DataEntrega.Value - hoje).Days;

                if (diasParaEntrega == 7 || diasParaEntrega == 2)
                {
                    var usuario = atividade.IdUsuarioNavigation;

                    var body = $@"
                <html>
                    <body>
                        <h2>Prazo de entrega se aproximando</h2>
                        <p>Olá {usuario.Nome},</p>
                        <p>A atividade <strong>{atividade.Nome}</strong> está com prazo de entrega para <strong>{atividade.DataEntrega:dd/MM/yyyy}</strong>.</p>
                        <p>Faltam apenas <strong>{diasParaEntrega}</strong> dias para o prazo final.</p>
                        <p>Por favor, verifique a atividade e garanta que tudo esteja pronto!</p>
                    </body>
                </html>";

                    await _emailService.SendEmailAsync(usuario.Email, "Prazo de entrega se aproximando", body);
                }
            }
        }
    }

}
