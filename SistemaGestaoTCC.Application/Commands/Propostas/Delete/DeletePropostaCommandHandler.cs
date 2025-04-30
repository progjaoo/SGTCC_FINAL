using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Propostas.Delete
{
    public class DeletePropostaCommandHandler : IRequestHandler<DeletePropostaCommand, Unit>
    {
        private readonly IPropostaRepository _propostaRepository;
        public DeletePropostaCommandHandler(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }
        public async Task<Unit> Handle(DeletePropostaCommand request, CancellationToken cancellationToken)
        {
            var proposta = await _propostaRepository.GetByIdAsync(request.Id);
            
            await _propostaRepository.DeleteAsync(proposta.Id);
            await _propostaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
