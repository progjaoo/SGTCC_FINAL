using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AvaliadorBancaVM;

namespace SistemaGestaoTCC.Application.Queries.AvaliadorBancas.GetById
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
