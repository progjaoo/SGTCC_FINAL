using MediatR;
using SistemaGestaoTCC.Application.ViewModels.PropostasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Propostas.GetById
{
    public class GetPropostaByIdQueryHandler : IRequestHandler<GetPropostaByIdQuery, PropostaViewModel>
    {
        private readonly IPropostaRepository _propostaRepository;
        public GetPropostaByIdQueryHandler(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }
        public async Task<PropostaViewModel> Handle(GetPropostaByIdQuery request, CancellationToken cancellationToken)
        {
            var proposta = await _propostaRepository.GetByIdAsync(request.Id);

            if (proposta == null) return null;
      
            var propostaViewModel = new PropostaViewModel(
                proposta.Id,
                proposta.IdProjeto,
                proposta.AtividadesPropostas,
                proposta.ContribuicaoAgenda,
                proposta.Sugestao,
                proposta.Parecer,
                proposta.CriadoEm
            );
            return propostaViewModel;
        }
    }
}
