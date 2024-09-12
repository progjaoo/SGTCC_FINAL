using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.Categorias.Update
{
    public class UpdateCategoriaCommandHandler : IRequestHandler<UpdateCategoriaCommand, Unit>
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public UpdateCategoriaCommandHandler(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public async Task<Unit> Handle(UpdateCategoriaCommand request, CancellationToken cancellationToken)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(request.Id);

            categoria.UpdateCategoria(request.Valor);

            await _categoriaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
