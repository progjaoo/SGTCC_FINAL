using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Propostas.Create
{
    public class CreatePropostaCommandHandler : IRequestHandler<CreatePropostaCommand, int>
    {
        private readonly IPropostaRepository _propostaRepository;

        public CreatePropostaCommandHandler(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public async Task<int> Handle(CreatePropostaCommand request, CancellationToken cancellationToken)
        {
            var proposta = new Proposta(request.IdProjeto, request.AtividadesPropostas, request.ContribuicaoAgenda, request.Sugestao);
            
            await _propostaRepository.AddAsync(proposta);
            await _propostaRepository.SaveChangesAsync();

            return proposta.Id;
        }
    }
}
