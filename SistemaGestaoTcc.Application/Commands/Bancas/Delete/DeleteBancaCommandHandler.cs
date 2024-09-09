using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.Bancas.Delete
{
    public class DeleteBancaCommandHandler : IRequestHandler<DeleteBancaCommand, Unit>
    {
        private readonly IBancaRepository _bancaRepository;
        public DeleteBancaCommandHandler(IBancaRepository bancaRepository)
        {
            _bancaRepository = bancaRepository;
        }
        public async Task<Unit> Handle(DeleteBancaCommand request, CancellationToken cancellationToken)
        {
            var banca = await _bancaRepository.GetById(request.Id);

            if (banca == null)
                throw new Exception("banca não encontrado");

            await _bancaRepository.DeleteBanca(banca.Id);
            await _bancaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
