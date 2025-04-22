using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Anotacoes.GetByUser
{
    public class GetAnotacaoByUserQueryHandler : IRequestHandler<GetAnotacaoByUserQuery, List<AnotacaoViewModel>>
    {
        private readonly IAnotacaoRepository _anotacaoRepository;
        public GetAnotacaoByUserQueryHandler(IAnotacaoRepository anotacaoRepository)
        {
            _anotacaoRepository = anotacaoRepository;
        }
        public async Task<List<AnotacaoViewModel>> Handle(GetAnotacaoByUserQuery request, CancellationToken cancellationToken)
        {
            var anotacao = await _anotacaoRepository.GetAnotacaoByUserAsync(request.IdUsuario);

            if (anotacao == null)
                return null;
            
            var anotacaoViewModel = anotacao.Select(a => new AnotacaoViewModel(a.IdUsuario, a.IdProjeto, a.Titulo, a.Descricao)).ToList();

            return anotacaoViewModel;
        }
    }
}