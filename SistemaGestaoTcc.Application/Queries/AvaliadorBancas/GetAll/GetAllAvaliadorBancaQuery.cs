using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AvaliadorBancaVM;

namespace SistemaGestaoTcc.Application.Queries.AvaliadorBancas.GetAll
{
    public class GetAllAvaliadorBancaQuery : IRequest<List<AvaliadorBancaViewModel>>
    {
    }

}
