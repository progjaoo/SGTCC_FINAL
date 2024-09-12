using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.Categorias.Create
{
    public class CreateCategoriaCommandHandler : IRequestHandler<CreateCategoriaCommand, int>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CreateCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<int> Handle(CreateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = new Categoria(request.Valor);

            await _categoriaRepository.AddAsync(categoria);
            await _categoriaRepository.SaveChangesAsync();

            return categoria.Id;
        }
    }
}
