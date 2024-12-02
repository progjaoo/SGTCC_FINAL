using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AvaliadorBancaVM;

namespace SistemaGestaoTCC.Application.Queries.AvaliadorBancas.GetAll
{
    public class GetAllAvaliadorBancaQuery : IRequest<List<AvaliadorBancaViewModel>>
    {
    }

}
