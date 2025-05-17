using MediatR;
using SistemaGestaoTCC.Application.ViewModels.PropostasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Propostas.GetAll
{
    public class GetAllPropostasQueryHandler : IRequestHandler<GetAllPropostasQuery, List<PropostaViewModel>>
    {
        private readonly IPropostaRepository _propostaRepository;
        public GetAllPropostasQueryHandler(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }
        public async Task<List<PropostaViewModel>> Handle(GetAllPropostasQuery request, CancellationToken cancellationToken)
        {
            var propostas = await _propostaRepository.GetAllAsync();

            var propostasViewModel = propostas.Select(p => new PropostaViewModel(
                p.Id,
                p.IdProjeto,
                p.IdProjetoNavigation?.Nome,
                p.IdProjetoNavigation?.Descricao,
                p.IdProjetoNavigation?.Justificativa,
                p.AtividadesPropostas,
                p.ContribuicaoAgenda,
                p.Sugestao,
                p.Parecer
            )).ToList();

            return propostasViewModel;
        }
    }
}
