using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.RespostaDuvidas.GetAll
{
    public class GetAllRespostaDuvidaQueryHandler : IRequestHandler<GetAllRespostaDuvidaQuery, List<RespostaDuvidaViewModel>>
    {
        private readonly IRespostaDuvidaRepository _respostaRepository;

        public GetAllRespostaDuvidaQueryHandler(IRespostaDuvidaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        public async Task<List<RespostaDuvidaViewModel>> Handle(GetAllRespostaDuvidaQuery request, CancellationToken cancellationToken)
        {
            var respostas = await _respostaRepository.GetAllAsync();

            return respostas.Select(r => new RespostaDuvidaViewModel(
                r.Id, r.IdDuvida, r.IdUsuario, r.Texto, r.IdUsuarioNavigation?.Nome, r.CriadoEm)).ToList();
        }
    }
}
