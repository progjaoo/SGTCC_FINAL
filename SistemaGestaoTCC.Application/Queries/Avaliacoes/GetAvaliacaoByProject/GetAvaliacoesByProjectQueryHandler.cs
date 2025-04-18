using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AvaliacaoVM;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Avaliacoes.GetAvaliacaoByProject
{
    public class GetAvaliacoesByProjectQueryHandler : IRequestHandler<GetAvaliacoesByProjectQuery, List<AvaliacaoDetailProjectViewModel>>
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        public GetAvaliacoesByProjectQueryHandler(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }
        public async Task<List<AvaliacaoDetailProjectViewModel>> Handle(GetAvaliacoesByProjectQuery request, CancellationToken cancellationToken)
        {
            var avaliacao = await _avaliacaoRepository.GetAvaliacoesByProjectAsync(request.Id);

            var avaliacaoViewModel = avaliacao
                .Select(p => new AvaliacaoDetailProjectViewModel(p.Id, p.IdUsuario, p.Avaliacao))
                .ToList();

            return avaliacaoViewModel;
        }
    }
}
