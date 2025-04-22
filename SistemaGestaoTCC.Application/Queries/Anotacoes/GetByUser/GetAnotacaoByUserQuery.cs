using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;

namespace SistemaGestaoTCC.Application.Queries.Anotacoes.GetByUser
{
    public class GetAnotacaoByUserQuery : IRequest<List<AnotacaoViewModel>>
    {
        public GetAnotacaoByUserQuery(int idUsuario)
        {
            IdUsuario = idUsuario;
        }
        public int IdUsuario { get; set; }
    }
}
