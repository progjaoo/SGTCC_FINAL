using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetAllSeminarios
{
    public class GetAllSeminariosQueryHandler : IRequestHandler<GetAllSeminariosQuery, List<SeminarioViewModel>>
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public GetAllSeminariosQueryHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }
        public async Task<List<SeminarioViewModel>> Handle(GetAllSeminariosQuery request, CancellationToken cancellationToken)
        {
            var seminarios = await _seminarioRepository.GetAllAsync();
            
            var seminariosViewModel = seminarios.Select(s => new SeminarioViewModel(s.Id, s.IdUsuario, s.Requisitos, s.Data, s.IdUsuarioNavigation?.Nome)).ToList();

            return seminariosViewModel;
        }
    }
}
