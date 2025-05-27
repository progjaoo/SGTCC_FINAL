using MediatR;
using SistemaGestaoTCC.Application.ViewModels.PropostasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Propostas.GetAllByCourse
{
    public class GetAllByCoursePropostasQueryHandler : IRequestHandler<GetAllByCoursePropostasQuery, List<PropostaViewModel>>
    {
        private readonly IPropostaRepository _propostaRepository;
        public GetAllByCoursePropostasQueryHandler(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }
        public async Task<List<PropostaViewModel>> Handle(GetAllByCoursePropostasQuery request, CancellationToken cancellationToken)
        {
            var propostas = await _propostaRepository.GetAllByCourse(request.Id);

            var propostasViewModel = propostas.Select(p => new PropostaViewModel(
                p.Id,
                p.IdProjeto,
                p.IdProjetoNavigation?.Nome,
                p.IdProjetoNavigation?.Descricao,
                p.IdProjetoNavigation?.Justificativa,
                p.AtividadesPropostas,
                p.ContribuicaoAgenda,
                p.Sugestao,
                p.Parecer,
                p.CriadoEm
            )).ToList();

            return propostasViewModel;
        }
    }
}
