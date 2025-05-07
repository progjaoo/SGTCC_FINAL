using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetAll
{
    public class GetAllDuvidasQueryHandler : IRequestHandler<GetAllDuvidasQuery, List<DuvidasViewModel>>
    {
        private readonly IDuvidaRepository _duvidaRepository;

        public GetAllDuvidasQueryHandler(IDuvidaRepository duvidaRepository)
        {
            _duvidaRepository = duvidaRepository;
        }

        public async Task<List<DuvidasViewModel>> Handle(GetAllDuvidasQuery request, CancellationToken cancellationToken)
        {
            var duvidas = await _duvidaRepository.GetAllAsync();
            return duvidas.Select(a => new DuvidasViewModel(a.Id, a.IdProjeto, a.IdUsuario, a.Texto, a.Visibilidade, a.Atendida, a.CriadoEm)).ToList();
        }
    }
}
