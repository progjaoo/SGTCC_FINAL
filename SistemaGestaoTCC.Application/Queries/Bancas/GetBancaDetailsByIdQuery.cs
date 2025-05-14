using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BacanVM;

namespace SistemaGestaoTCC.Application.Queries.Bancas
{
    public class GetBancaDetailsByIdQuery : IRequest<BancaProjetoDetalhesDetalhesViewModel>
    {
        public int IdBanca { get; set; }

        public GetBancaDetailsByIdQuery(int idBanca)
        {
            IdBanca = idBanca;
        }
    }

}
