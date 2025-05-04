using MediatR;
using SistemaGestaoTCC.Application.Queries.Relatorios.GetRelatorioByUser;
using SistemaGestaoTCC.Application.ViewModels.RelatoriosVM;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Relatorios.GetRelatorioByProject
{
    public class GetRelatorioByProjectQueryHandler : IRequestHandler<GetRelatorioByProjectQuery, List<RelatorioViewModel>>
    {
        private readonly IRelatorioAcompanhamentoRepository _relatorioAcompanhamentoRepository;
        public GetRelatorioByProjectQueryHandler(IRelatorioAcompanhamentoRepository relatorioAcompanhamentoRepository)
        {
            _relatorioAcompanhamentoRepository = relatorioAcompanhamentoRepository;
        }
        public async Task<List<RelatorioViewModel>> Handle(GetRelatorioByProjectQuery request, CancellationToken cancellationToken)
        {
            var relatorios = await _relatorioAcompanhamentoRepository.GetRelatorioByProjectAsync(request.IdProjeto);

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
