using MediatR;
using SistemaGestaoTcc.Application.ViewModels.CategoriaVM;

namespace SistemaGestaoTcc.Application.Queries.Categorias.GetById
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
