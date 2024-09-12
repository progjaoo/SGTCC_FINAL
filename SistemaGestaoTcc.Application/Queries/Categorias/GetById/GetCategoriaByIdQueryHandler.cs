using MediatR;
using SistemaGestaoTcc.Application.ViewModels.CategoriaVM;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.Categorias.GetById
{
    public class GetCategoriaByIdQueryHandler : IRequestHandler<GetCategoriaByIdQuery, CategoriaViewModel>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public GetCategoriaByIdQueryHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<CategoriaViewModel> Handle(GetCategoriaByIdQuery request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(request.Id);

            var categoriaViewModel = new CategoriaViewModel(categoria.Id, categoria.Valor);

            return categoriaViewModel;
        }
    }
}
