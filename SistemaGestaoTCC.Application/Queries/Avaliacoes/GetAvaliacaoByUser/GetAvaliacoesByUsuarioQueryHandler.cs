using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Application.ViewModels.AvaliacaoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Avaliacoes.GetAvaliacaoByUser
{
    public class GetAvaliacoesByUsuarioQueryHandler : IRequestHandler<GetAvaliacoesByUsuarioQuery, List<AvaliacaoDetailViewModel>>
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        public GetAvaliacoesByUsuarioQueryHandler(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }
        public async Task<List<AvaliacaoDetailViewModel>> Handle(GetAvaliacoesByUsuarioQuery request, CancellationToken cancellationToken)
        {
            var avaliacao = await _avaliacaoRepository.GetAvaliacoesByUsuarioAsync(request.Id);

            var avaliacaoViewModel = avaliacao
                .Select(p => new AvaliacaoDetailViewModel(/*p.Id,p.IdUsuario, */p.IdProjeto, p.Avaliacao))
                .ToList();

            return avaliacaoViewModel;
        }
    }
}
