using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AvaliacaoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Avaliacoes.GetById
{
    public class GetAvaliacaoByIdQueryHandler : IRequestHandler<GetAvaliacaoByIdQuery, AvaliacaoDetailViewModel>
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        public GetAvaliacaoByIdQueryHandler(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }
        public async Task<AvaliacaoDetailViewModel> Handle(GetAvaliacaoByIdQuery request, CancellationToken cancellationToken)
        {
            var avaliacao = await _avaliacaoRepository.GetById(request.Id);

            if (avaliacao == null) return null;

            var avaliacaoViewModel = new AvaliacaoDetailViewModel(
                avaliacao.Id,
                avaliacao.IdUsuario, 
                avaliacao.IdProjeto, 
                avaliacao.Avaliacao);

            return avaliacaoViewModel;
        }
    }
}