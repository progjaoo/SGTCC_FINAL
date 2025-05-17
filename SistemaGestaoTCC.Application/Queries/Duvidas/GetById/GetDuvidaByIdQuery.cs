using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetById
{
    public class GetDuvidaByIdQuery : IRequest<DuvidasViewModel>
    {
        public GetDuvidaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
