using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetAtividadeByUser
{
    public class GetAtividadeByUserQueryHandler : IRequestHandler<GetAtividadeByUserQuery, List<ProjetoAtividadeDetalheViewModel>>
    {
        private readonly IProjetoAtividadeRepository _atividadeRepositorio;
        public GetAtividadeByUserQueryHandler(IProjetoAtividadeRepository atividadeRepositorio)
        {
            _atividadeRepositorio = atividadeRepositorio;
        }
        public async Task<List<ProjetoAtividadeDetalheViewModel>> Handle(GetAtividadeByUserQuery request, CancellationToken cancellationToken)
        {
            var atividades = await _atividadeRepositorio.GetAtividadeByUserAsync(request.IdUsuario);

            var atividadeViewModel = atividades.Select(a => new ProjetoAtividadeDetalheViewModel
            (
                a.Id, a.IdProjeto, a.Nome, a.Descricao,
                a.Estado, a.CriadoEm, a.IdUsuario,
                a.DuracaoEstimada, a.Prioridade,
                a.DataInicio, a.DataEntrega
            )).ToList();

            return atividadeViewModel;
        }
    }
}
