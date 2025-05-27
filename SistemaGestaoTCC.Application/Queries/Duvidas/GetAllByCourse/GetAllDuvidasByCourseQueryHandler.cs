using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetAllByCourse
{
    public class GetAllDuvidasByCourseQueryHandler : IRequestHandler<GetAllDuvidasByCourseQuery, List<DuvidasViewModel>>
    {
        private readonly IDuvidaRepository _duvidaRepository;

        public GetAllDuvidasByCourseQueryHandler(IDuvidaRepository duvidaRepository)
        {
            _duvidaRepository = duvidaRepository;
        }

        public async Task<List<DuvidasViewModel>> Handle(GetAllDuvidasByCourseQuery request, CancellationToken cancellationToken)
        {
            var duvidas = await _duvidaRepository.GetAllByCursoAsync(request.Id);
            return duvidas.Select(a => new DuvidasViewModel(a.Id, a.IdProjeto, a.IdUsuario, a.Texto, a.Visibilidade, a.Atendida, a.CriadoEm, a.IdUsuarioNavigation.Nome)).ToList();
        }
    }
}
