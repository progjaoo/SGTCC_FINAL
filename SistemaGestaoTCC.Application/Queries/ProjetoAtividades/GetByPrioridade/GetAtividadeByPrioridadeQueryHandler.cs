using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByPrioridade
{
    public class GetAtividadeByPrioridadeQueryHandler : IRequestHandler<GetAtividadeByPrioridadeQuery, List<ProjetoAtividadeDetalheViewModel>>
    {
        private readonly IProjetoAtividadeRepository _atividadeRepositorio;
        public GetAtividadeByPrioridadeQueryHandler(IProjetoAtividadeRepository atividadeRepositorio)
        {
            _atividadeRepositorio = atividadeRepositorio;
        }
        public async Task<List<ProjetoAtividadeDetalheViewModel>> Handle(GetAtividadeByPrioridadeQuery request, CancellationToken cancellationToken)
        {
            var atividade = await _atividadeRepositorio.GetAtividadeByPrioridadeIdAsync(request.Prioridade, request.IdProjeto);

            var atividadeViewModel = atividade.Select(a => new ProjetoAtividadeDetalheViewModel
            (
                a.Id, a.IdProjeto, a.Nome, a.Descricao,
                a.Estado, a.CriadoEm, a.IdUsuario,
                a.DuracaoEstimada, a.Prioridade,
                a.DataInicio, a.DataEntrega, a.IdUsuarioNavigation?.Nome
            )).ToList();

            return atividadeViewModel;
        }
    }
}
