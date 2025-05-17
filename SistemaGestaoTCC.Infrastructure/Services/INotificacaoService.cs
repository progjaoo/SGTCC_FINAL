using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Infrastructure.Services
{
    public interface INotificacaoService
    {
        Task NotificarPrazoEntregaAtividadesAsync();
    }
}
