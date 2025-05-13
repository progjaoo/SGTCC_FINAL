using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DashaboarVM;

namespace SistemaGestaoTCC.Application.Queries.Dashboard
{
    public class GetDashboardProjetoQuery : IRequest<DashboardProjetoViewModel>
    {
        public int ProjetoId { get; }

        public GetDashboardProjetoQuery(int projetoId)
        {
            ProjetoId = projetoId;
        }
    }

}
