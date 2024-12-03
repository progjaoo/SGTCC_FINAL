using MediatR;
using SistemaGestaoTCC.Application.ViewModels.CategoriaVM;

namespace SistemaGestaoTCC.Application.Queries.Categorias.GetById
{
    public class GetCategoriaByIdQuery : IRequest<CategoriaViewModel>
    {

        public GetCategoriaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
