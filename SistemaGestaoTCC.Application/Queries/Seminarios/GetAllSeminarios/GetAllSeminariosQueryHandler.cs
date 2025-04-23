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
            return seminarios.Select(s => new SeminarioViewModel(s.IdUsuario, s.Requisitos, s.Data)).ToList();
        }
    }
}
