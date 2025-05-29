using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetAllSeminariosByProjectId
{
    public class GetAllSeminariosByProjectIdQueryHandler : IRequestHandler<GetAllSeminariosByProjectIdQuery, List<SeminarioViewModel>>
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public GetAllSeminariosByProjectIdQueryHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }
        public async Task<List<SeminarioViewModel>> Handle(GetAllSeminariosByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var seminarios = await _seminarioRepository.GetAllByProjectId(request.Id);

            var seminariosViewModel = seminarios.Select(s => new SeminarioViewModel(s.Id, s.IdUsuario, s.Requisitos, s.Data, s.IdUsuarioNavigation?.Nome)).ToList();

            return seminariosViewModel;
        }
    }
}
