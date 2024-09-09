using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AvaliadorBancaVM;

namespace SistemaGestaoTcc.Application.Queries.AvaliadorBancas.GetById
{
    public class GetAvaliadorBancaByIdQuery : IRequest<AvaliadorBancaDetalheViewModel>
    {

        public GetAvaliadorBancaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
