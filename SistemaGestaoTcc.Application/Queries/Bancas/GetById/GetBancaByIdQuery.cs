using MediatR;
using SistemaGestaoTcc.Application.ViewModels.BacanVM;

namespace SistemaGestaoTcc.Application.Queries.Bancas.GetById
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
