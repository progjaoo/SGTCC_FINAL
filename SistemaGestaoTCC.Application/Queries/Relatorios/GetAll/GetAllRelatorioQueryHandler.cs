using MediatR;
using SistemaGestaoTCC.Application.ViewModels.RelatoriosVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Relatorios.GetAll
{
    public class GetAllRelatorioQueryHandler : IRequestHandler<GetAllRelatorioQuery, List<RelatorioViewModel>>
    {
        private readonly IRelatorioAcompanhamentoRepository _relatorioAcompanhamentoRepository;
        public GetAllRelatorioQueryHandler(IRelatorioAcompanhamentoRepository relatorioAcompanhamentoRepository)
        {
            _relatorioAcompanhamentoRepository = relatorioAcompanhamentoRepository;
        }
        public async Task<List<RelatorioViewModel>> Handle(GetAllRelatorioQuery request, CancellationToken cancellationToken)
        {
            var relatorios = await _relatorioAcompanhamentoRepository.GetAllAsync();

            var relatorioViewModels = relatorios.Select(relatorio => new RelatorioViewModel(
                relatorio.Id,
                relatorio.IdProfessor,
                relatorio.IdProjeto,
                relatorio.Titulo,
                relatorio.Descricao,
                relatorio.DuracaoEncontro,
                relatorio.DataRealizacao,
                relatorio.CriadoEm,
                relatorio.IdUsuarioNavigation?.Nome,
                relatorio.IdProjetoNavigation?.Nome
            )).ToList();

            return relatorioViewModels;
        }
    }
}
