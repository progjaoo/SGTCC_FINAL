using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Bibliografias.Delete
{
    public class DeleteBibliografiaCommandHandler : IRequestHandler<DeleteBibliografiaCommand, Unit>
    {
        private readonly IBibliografiaRepository _bibliografiaRepository;
        public DeleteBibliografiaCommandHandler(IBibliografiaRepository bibliografiaRepository)
        {
            _bibliografiaRepository = bibliografiaRepository;
        }
        public async Task<Unit> Handle(DeleteBibliografiaCommand request, CancellationToken cancellationToken)
        {
            var bibliografia = await _bibliografiaRepository.GetById(request.Id);

            if (bibliografia == null)
            {
                throw new Exception("Bibliografia não encontrada");
            }

            await _bibliografiaRepository.DeleteAsync(bibliografia.Id);
            await _bibliografiaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }

}
