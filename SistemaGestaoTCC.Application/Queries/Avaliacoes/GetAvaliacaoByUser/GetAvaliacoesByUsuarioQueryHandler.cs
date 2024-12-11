using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Application.ViewModels.AvaliacaoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Avaliacoes.GetAvaliacaoByUser
{
    public class GetAvaliacoesByUsuarioQueryHandler : IRequestHandler<GetAvaliacoesByUsuarioQuery, List<AvaliacaoDetailUsuarioViewModel>>
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        public GetAvaliacoesByUsuarioQueryHandler(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }
        public async Task<List<AvaliacaoDetailUsuarioViewModel>> Handle(GetAvaliacoesByUsuarioQuery request, CancellationToken cancellationToken)
        {
            var avaliacao = await _avaliacaoRepository.GetAvaliacoesByUsuarioAsync(request.Id);

            var avaliacaoViewModel = avaliacao
                .Select(p => new AvaliacaoDetailUsuarioViewModel(p.IdProjeto, p.Avaliacao))
                .ToList();

            return avaliacaoViewModel;
        }
    }
}
