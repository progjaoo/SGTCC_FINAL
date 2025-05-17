using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetDuvidasByProjetoAndStatus
{
    public class GetDuvidasByProjetoAndStatusQueryHandler : IRequestHandler<GetDuvidasByProjetoAndStatusQuery, List<DuvidasViewModel>>
    {
        private readonly IDuvidaRepository _duvidaRepository;

        public GetDuvidasByProjetoAndStatusQueryHandler(IDuvidaRepository duvidaRepository)
        {
            _duvidaRepository = duvidaRepository;
        }

        public async Task<List<DuvidasViewModel>> Handle(GetDuvidasByProjetoAndStatusQuery request, CancellationToken cancellationToken)
        {
            var duvidas = await _duvidaRepository.GetByProjetoAndAtendidaAsync(request.IdProjeto, (RespotaDuvidaEnum)request.Atendida);
            var duvidasViewModel = duvidas.Select(d => new DuvidasViewModel(d.Id, d.IdProjeto, d.IdUsuario, 
                d.Texto, d.Visibilidade, d.Atendida, d.CriadoEm, d.IdUsuarioNavigation.Nome)).ToList();

            return duvidasViewModel;
        }
    }
}
