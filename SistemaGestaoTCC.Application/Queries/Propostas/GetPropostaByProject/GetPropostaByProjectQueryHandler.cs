using MediatR;
using SistemaGestaoTCC.Application.ViewModels.PropostasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Propostas.GetPropostaByProject
{
    public class GetPropostaByProjectQueryHandler : IRequestHandler<GetPropostaByProjectQuery, List<PropostaViewModel>>
    {
        private readonly IPropostaRepository _propostaRepository;
        public GetPropostaByProjectQueryHandler(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }
        public async Task<List<PropostaViewModel>> Handle(GetPropostaByProjectQuery request, CancellationToken cancellationToken)
        {
            var propostas = await _propostaRepository.GetPropostaByProject(request.IdProjeto);

            var propostaViewModel = propostas.Select(proposta => new PropostaViewModel(
                proposta.Id,
                proposta.IdProjeto,
                proposta.AtividadesPropostas,
                proposta.ContribuicaoAgenda,
                proposta.Sugestao,
                proposta.Parecer,
                proposta.CriadoEm
            )).ToList();

            return propostaViewModel;
        }
    }
}
