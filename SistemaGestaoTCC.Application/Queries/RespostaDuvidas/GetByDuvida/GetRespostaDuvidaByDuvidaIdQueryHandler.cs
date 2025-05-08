using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.RespostaDuvidas.GetByDuvida
{
    public class GetRespostaDuvidaByDuvidaIdQueryHandler : IRequestHandler<GetRespostaDuvidaByDuvidaIdQuery, List<RespostaDuvidaViewModel>>
    {
        private readonly IRespostaDuvidaRepository _respostaRepository;

        public GetRespostaDuvidaByDuvidaIdQueryHandler(IRespostaDuvidaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        public async Task<List<RespostaDuvidaViewModel>> Handle(GetRespostaDuvidaByDuvidaIdQuery request, CancellationToken cancellationToken)
        {
            var respostas = await _respostaRepository.GetByDuvidaIdAsync(request.IdDuvida);

            return respostas.Select(r => new RespostaDuvidaViewModel(
                r.Id, r.IdDuvida, r.IdUsuario, r.Texto,
                r.IdUsuarioNavigation?.Nome, r.CriadoEm)).ToList();
        }
    }
}
