using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;

namespace SistemaGestaoTCC.Application.Queries.RespostaDuvidas.GetById
{
    public class GetRespostaDuvidaByIdQuery : IRequest<RespostaDuvidaViewModel>
    {
        public GetRespostaDuvidaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
