using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Propostas.Update
{
    public class UpdatePropostaCommandHandler : IRequestHandler<UpdatePropostaCommand, Unit>
    {
        private readonly IPropostaRepository _propostaRepository;
        public UpdatePropostaCommandHandler(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }
        public async Task<Unit> Handle(UpdatePropostaCommand request, CancellationToken cancellationToken)
        {
            var proposta = await _propostaRepository.GetByIdAsync(request.Id);
            if (proposta == null)
            {
                throw new Exception("Proposta não encontrada");
            }
            proposta.Update(request.AtividadesPropostas, request.ContribuicaoAgenda, request.Sugestao);

            await _propostaRepository.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}
