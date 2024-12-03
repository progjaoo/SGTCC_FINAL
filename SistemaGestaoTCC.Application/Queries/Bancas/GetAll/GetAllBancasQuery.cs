using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BacanVM;

namespace SistemaGestaoTCC.Application.Queries.Bancas.GetAll
{
    public class GetAllBancasQuery : IRequest<List<BancaViewModel>> { }
}
