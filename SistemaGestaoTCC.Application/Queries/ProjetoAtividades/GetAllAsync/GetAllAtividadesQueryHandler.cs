using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetAllAsync
{
    public class GetAllAtividadesQueryHandler : IRequestHandler<GetAllAtividadesQuery, List<ProjetoAtividadeViewModel>>
    {
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
        public GetAllAtividadesQueryHandler(IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _projetoAtividadeRepository = projetoAtividadeRepository;
        }
        public async Task<List<ProjetoAtividadeViewModel>> Handle(GetAllAtividadesQuery request, CancellationToken cancellationToken)
        {
            var atividade = await _projetoAtividadeRepository.GetAllAsync();

            var atividadeViewModel = atividade.Select(a => new ProjetoAtividadeViewModel(a.IdProjeto, a.Nome, a.DuracaoEstimada, a.IdUsuario, a.DataEntrega)).ToList();

            return atividadeViewModel;  
        }
    }
}
