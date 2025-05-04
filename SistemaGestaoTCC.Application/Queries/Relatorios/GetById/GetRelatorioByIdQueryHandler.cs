using MediatR;
using SistemaGestaoTCC.Application.ViewModels.RelatoriosVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Relatorios.GetById
{
    public class GetRelatorioByIdQueryHandler : IRequestHandler<GetRelatorioByIdQuery, RelatorioViewModel>
    {
        private readonly IRelatorioAcompanhamentoRepository _relatorioAcompanhamentoRepository;
        public GetRelatorioByIdQueryHandler(IRelatorioAcompanhamentoRepository relatorioAcompanhamentoRepository)
        {
            _relatorioAcompanhamentoRepository = relatorioAcompanhamentoRepository;
        }
        public async Task<RelatorioViewModel> Handle(GetRelatorioByIdQuery request, CancellationToken cancellationToken)
        {
            var relatorio = await _relatorioAcompanhamentoRepository.GetById(request.Id);

            if (relatorio == null) return null;

            var relatorioViewModel = new RelatorioViewModel(
                relatorio.IdProfessor,
                relatorio.IdProjeto,
                relatorio.Titulo,
                relatorio.Descricao,
                relatorio.DuracaoEncontro,
                relatorio.DataRealizacao,
                relatorio.CriadoEm,
                relatorio.IdUsuarioNavigation?.Nome,
                relatorio.IdProjetoNavigation?.Nome
            );

            return relatorioViewModel;
        }
    }
}
