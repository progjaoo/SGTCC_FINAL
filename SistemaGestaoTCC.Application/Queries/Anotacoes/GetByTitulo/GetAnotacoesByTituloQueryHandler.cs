using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Anotacoes.GetByTitulo
{
    public class GetAnotacoesByTituloQueryHandler : IRequestHandler<GetAnotacoesByTituloQuery, List<AnotacaoViewModel>>
    {
        private readonly IAnotacaoRepository _anotacaoRepository;

        public GetAnotacoesByTituloQueryHandler(IAnotacaoRepository anotacaoRepository)
        {
            _anotacaoRepository = anotacaoRepository;
        }

        public async Task<List<AnotacaoViewModel>> Handle(GetAnotacoesByTituloQuery request, CancellationToken cancellationToken)
        {
            var anotacoes = await _anotacaoRepository.GetAnotacoesByTituloAsync(request.Titulo, request.IdProjeto);

            return anotacoes.Select(a => new AnotacaoViewModel(a.IdUsuario, a.IdProjeto, a.Titulo, a.Descricao, a.CriadoEm)).ToList();
        }
    }
}