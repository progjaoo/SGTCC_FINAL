using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.RespostaDuvidas.GetByUser
{
    public class GetRespostaDuvidaByUsuarioIdQueryHandler : IRequestHandler<GetRespostaDuvidaByUsuarioIdQuery, List<RespostaDuvidaViewModel>>
    {
        private readonly IRespostaDuvidaRepository _respostaRepository;

        public GetRespostaDuvidaByUsuarioIdQueryHandler(IRespostaDuvidaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        public async Task<List<RespostaDuvidaViewModel>> Handle(GetRespostaDuvidaByUsuarioIdQuery request, CancellationToken cancellationToken)
        {
            var respostas = await _respostaRepository.GetByUsuarioIdAsync(request.IdUsuario);

            return respostas.Select(r => new RespostaDuvidaViewModel(
                r.Id, r.IdDuvida, r.IdUsuario, r.Texto,
                r.IdUsuarioNavigation?.Nome, r.CriadoEm)).ToList();
        }
    }
}
