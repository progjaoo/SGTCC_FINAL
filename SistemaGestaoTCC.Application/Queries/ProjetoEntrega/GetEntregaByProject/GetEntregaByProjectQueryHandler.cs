using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoEntregaVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoEntrega.GetEntregaByProject
{
    public class GetEntregaByProjectQueryHandler : IRequestHandler<GetEntregaByProjectQuery, List<ProjetoEntregaViewModel>>
    {
        private readonly IProjetoEntregaRepository _projetoEntregaRepository;
        public GetEntregaByProjectQueryHandler(IProjetoEntregaRepository projetoEntregaRepository)
        {
            _projetoEntregaRepository = projetoEntregaRepository;
        }
        public async Task<List<ProjetoEntregaViewModel>> Handle(GetEntregaByProjectQuery request, CancellationToken cancellationToken)
        {
            var entregas = await _projetoEntregaRepository.GetEntregasByProjetoIdAsync(request.IdProjeto);

            if (entregas == null)
                throw new Exception("Projeto não encontrado");

            var entregasViewModel = entregas.Select(e => new ProjetoEntregaViewModel(
                e.Id,
                e.Titulo,
                e.Entregue)).ToList();   
            
            return entregasViewModel;
        }
    }
}