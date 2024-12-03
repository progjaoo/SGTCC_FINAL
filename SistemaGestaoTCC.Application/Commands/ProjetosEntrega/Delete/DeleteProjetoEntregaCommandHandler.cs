using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.ProjetosEntrega.Delete
{
    public class DeleteProjetoEntregaCommandHandler : IRequestHandler<DeleteProjetoEntregaCommand, Unit>
    {
        private readonly IProjetoEntregaRepository _projetoEntregaRepository;
        public DeleteProjetoEntregaCommandHandler(IProjetoEntregaRepository projetoEntregaRepository)
        {
            _projetoEntregaRepository = projetoEntregaRepository;
        }
        public async Task<Unit> Handle(DeleteProjetoEntregaCommand request, CancellationToken cancellationToken)
        {
            var entrega = await _projetoEntregaRepository.GetByIdAsync(request.Id);

            if (entrega == null)
                throw new Exception("Entrega não encontrada!");

            await _projetoEntregaRepository.DeleteAsync(entrega.Id);
            await _projetoEntregaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
