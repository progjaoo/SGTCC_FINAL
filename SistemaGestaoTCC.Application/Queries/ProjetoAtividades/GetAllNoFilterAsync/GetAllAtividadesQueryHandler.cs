using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByProjectNoFilter
{
    public class GetByProjectIdNoFilterQueryHandler : IRequestHandler<GetByProjectIdNoFilterQuery, List<ProjetoAtividadeDetalheViewModel>>
    {
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
        public GetByProjectIdNoFilterQueryHandler(IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _projetoAtividadeRepository = projetoAtividadeRepository;
        }
        public async Task<List<ProjetoAtividadeDetalheViewModel>> Handle(GetByProjectIdNoFilterQuery request, CancellationToken cancellationToken)
        {
            var atividades = await _projetoAtividadeRepository.GetAtividadeByProjectIdNoFilterAsync(request.IdProjeto);

            var atividadeViewModel = atividades.Select(a => new ProjetoAtividadeDetalheViewModel
            (
                a.Id, a.IdProjeto, a.Nome, a.Descricao, 
                a.Estado, a.CriadoEm, a.IdUsuario, a.DuracaoEstimada, 
                a.Prioridade,a.DataInicio, a.DataEntrega
            )).ToList();

            return atividadeViewModel;
        }
    }
}
