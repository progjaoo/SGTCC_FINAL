using MediatR;
using SistemaGestaoTCC.Application.ViewModels.CategoriaVM;

namespace SistemaGestaoTCC.Application.Queries.Categorias.GetAll
{
    public class GetAllCategoriaQuery : IRequest<List<CategoriaViewModel>> { }
}
