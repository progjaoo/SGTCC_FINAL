using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetSeminariosProjetosById
{
    public class GetSeminariosProjetoByIdQueryHandler : IRequestHandler<GetSeminariosProjetoByIdQuery, SeminarioProjetosViewModel>
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public GetSeminariosProjetoByIdQueryHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }

        public async Task<SeminarioProjetosViewModel> Handle(GetSeminariosProjetoByIdQuery request, CancellationToken cancellationToken)
        {
            var seminarioProjeto = await _seminarioRepository.GetSeminarioProjetoByIdAsync(request.Id);

            if (seminarioProjeto == null)
            {
                throw new Exception("Busca não encontrada");
            }

            var seminarioViewModel = new SeminarioProjetosViewModel(seminarioProjeto.Id, seminarioProjeto.IdSeminario,
                seminarioProjeto.IdProjeto, seminarioProjeto.CriadoEm, seminarioProjeto.EditadoEm);

            return seminarioViewModel;
        }
    }

}
