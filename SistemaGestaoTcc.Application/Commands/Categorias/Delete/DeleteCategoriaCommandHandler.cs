using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.Categorias.Delete
{
    public class DeleteCategoriaCommandHandler : IRequestHandler<DeleteCategoriaCommand, Unit>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public DeleteCategoriaCommandHandler(ICategoriaRepository categoria)
        {
            _categoriaRepository = categoria;
        }

        public async Task<Unit> Handle(DeleteCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(request.Id);

            if (categoria == null)
                throw new Exception("categoria não encontrado");

            await _categoriaRepository.DeleteAsync(categoria.Id);

            await _categoriaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
