using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Anotacoes.GetById
{
    public class GetAnotacaoByIdQueryHandler : IRequestHandler<GetAnotacaoByIdQuery, AnotacaoDetalheViewModel>
    {
        private readonly IAnotacaoRepository _anotacaoRepository;
        public GetAnotacaoByIdQueryHandler(IAnotacaoRepository anotacaoRepository)
        {
            _anotacaoRepository = anotacaoRepository;
        }
        public async Task<AnotacaoDetalheViewModel> Handle(GetAnotacaoByIdQuery request, CancellationToken cancellationToken)
        {
            var anotacao = await _anotacaoRepository.GetById(request.Id);

            if (anotacao == null)
            {
                return null;
            }

            var anotacaoViewModel = new AnotacaoDetalheViewModel
                (anotacao.Id,
                anotacao.IdUsuario,
                anotacao.IdProjeto,
                anotacao.Titulo,
                anotacao.Descricao,
                anotacao.CriadoEm,
                anotacao.EditadoEm);

            return anotacaoViewModel;
        }
    }
}
