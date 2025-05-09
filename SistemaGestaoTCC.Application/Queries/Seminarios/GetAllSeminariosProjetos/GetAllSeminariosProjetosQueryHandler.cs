using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetAllSeminariosProjetos
{
    public class GetAllSeminariosProjetosQueryHandler : IRequest<List<SeminarioProjetosViewModel>>
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public GetAllSeminariosProjetosQueryHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }
        public async Task<List<SeminarioProjetosViewModel>> Handle(GetAllSeminariosProjetosQuery request, CancellationToken cancellationToken)
        {
            var seminariosProjeto = await _seminarioRepository.GetAllSeminarioProjeto();
           
            var seminariosProjetoViewModel = seminariosProjeto.Select(s => new SeminarioProjetosViewModel(s.IdSeminario, s.IdProjeto)).ToList();
           
            return seminariosProjetoViewModel;
        }
    }
}