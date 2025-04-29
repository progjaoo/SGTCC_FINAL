using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Anotacoes.GetByProject
{
    public class GetAnotacaoByProjectQueryHandler : IRequestHandler<GetAnotacaoByProjectQuery, List<AnotacaoViewModel>>
    {
        private readonly IAnotacaoRepository _anotacaoRepository;
        public GetAnotacaoByProjectQueryHandler(IAnotacaoRepository anotacaoRepository)
        {
            _anotacaoRepository = anotacaoRepository;
        }
        public async Task<List<AnotacaoViewModel>> Handle(GetAnotacaoByProjectQuery request, CancellationToken cancellationToken)
        {
            var anotacao = await _anotacaoRepository.GetAnotacaoByIdProjectAsync(request.IdProjeto);

            if (anotacao == null)
                return null;

            var anotacaoViewModel = anotacao.Select(a => new AnotacaoViewModel(a.Id,a.IdUsuario, a.IdProjeto, a.Titulo, a.Descricao,a.CriadoEm)).ToList();

            return anotacaoViewModel;
        }
    }
}
