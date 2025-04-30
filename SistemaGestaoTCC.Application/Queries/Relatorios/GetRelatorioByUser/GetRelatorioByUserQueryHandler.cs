using MediatR;
using SistemaGestaoTCC.Application.ViewModels.RelatoriosVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Relatorios.GetRelatorioByUser
{
    public class GetRelatorioByUserQueryHandler : IRequestHandler<GetRelatorioByUserQuery, List<RelatorioViewModel>>
    {
        private readonly IRelatorioAcompanhamentoRepository _relatorioAcompanhamentoRepository;
        public GetRelatorioByUserQueryHandler(IRelatorioAcompanhamentoRepository relatorioAcompanhamentoRepository)
        {
            _relatorioAcompanhamentoRepository = relatorioAcompanhamentoRepository;
        }
        public async Task<List<RelatorioViewModel>> Handle(GetRelatorioByUserQuery request, CancellationToken cancellationToken)
        {
            var relatorios = await _relatorioAcompanhamentoRepository.GetRelatorioByUserAsync(request.IdUsuario);

            var relatorioViewModels = relatorios.Select(relatorio => new RelatorioViewModel(
                relatorio.IdProfessor,
                relatorio.IdProjeto,
                relatorio.Titulo,
                relatorio.Descricao,
                relatorio.DuracaoEncontro,
                relatorio.DataRealizacao,
                relatorio.CriadoEm
            )).ToList();

            return relatorioViewModels;
        }
    }
}
