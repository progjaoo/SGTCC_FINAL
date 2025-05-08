using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;

namespace SistemaGestaoTCC.Application.Queries.RespostaDuvidas.GetByDuvida
{
    public class GetRespostaDuvidaByDuvidaIdQuery : IRequest<List<RespostaDuvidaViewModel>>
    {
        public GetRespostaDuvidaByDuvidaIdQuery(int idDuvida)
        {
            IdDuvida = idDuvida;
        }
        public int IdDuvida { get; set; }
    }
}
