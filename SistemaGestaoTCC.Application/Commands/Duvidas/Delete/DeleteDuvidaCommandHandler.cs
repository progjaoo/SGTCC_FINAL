using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Duvidas.Delete
{
    public class DeleteDuvidaCommandHandler : IRequestHandler<DeleteDuvidaCommand, Unit>
    {
        private readonly IDuvidaRepository _duvidaRepository;

        public DeleteDuvidaCommandHandler(IDuvidaRepository duvidaRepository)
        {
            _duvidaRepository = duvidaRepository;
        }

        public async Task<Unit> Handle(DeleteDuvidaCommand request, CancellationToken cancellationToken)
        {
            var duvida = await _duvidaRepository.GetByIdAsync(request.Id);
            if (duvida == null)
            {
                throw new Exception("Dúvida não encontrada");
            }
            await _duvidaRepository.Delete(duvida.Id);
            await _duvidaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
