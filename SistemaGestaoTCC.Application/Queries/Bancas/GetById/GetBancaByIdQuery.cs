using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BacanVM;

namespace SistemaGestaoTCC.Application.Queries.Bancas.GetById
{
    public class GetBancaByIdQuery : IRequest<BancaDetailViewModel>
    {
        public GetBancaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
