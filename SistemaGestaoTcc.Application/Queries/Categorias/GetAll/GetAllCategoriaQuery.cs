using MediatR;
using SistemaGestaoTcc.Application.ViewModels.CategoriaVM;

namespace SistemaGestaoTcc.Application.Queries.Categorias.GetAll
{
    public class GetAllCategoriaQuery : IRequest<List<CategoriaViewModel>> { }
}
