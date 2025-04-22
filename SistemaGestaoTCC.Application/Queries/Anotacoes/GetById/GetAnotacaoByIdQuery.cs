using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;

namespace SistemaGestaoTCC.Application.Queries.Anotacoes.GetById
{
    public class GetAnotacaoByIdQuery : IRequest<AnotacaoDetalheViewModel>
    {
        public GetAnotacaoByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
