using MediatR;
using SistemaGestaoTcc.Application.ViewModels.BacanVM;

namespace SistemaGestaoTcc.Application.Queries.Bancas.GetAll
{
    public class GetAllBancasQuery : IRequest<List<BancaViewModel>> { }
}
