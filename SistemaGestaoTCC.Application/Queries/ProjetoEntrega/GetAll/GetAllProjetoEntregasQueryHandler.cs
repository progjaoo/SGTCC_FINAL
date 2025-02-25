using MediatR;

using SistemaGestaoTCC.Application.ViewModels.ProjetoEntregaVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoEntrega.GetAll
{
    public class GetAllProjetoEntregasQueryHandler : IRequestHandler<GetAllProjetoEntregasQuery, List<ProjetoEntregaViewModel>>
    {
        private readonly IProjetoEntregaRepository _projetoEntregaRepository;

        public GetAllProjetoEntregasQueryHandler(IProjetoEntregaRepository projetoEntregaRepository)
        {
            _projetoEntregaRepository = projetoEntregaRepository;
        }

        public async Task<List<ProjetoEntregaViewModel>> Handle(GetAllProjetoEntregasQuery request, CancellationToken cancellationToken)
        {
            var entrega = await _projetoEntregaRepository.GetAllAsync();

            var entregaViewModel = entrega.Select(e => new ProjetoEntregaViewModel(e.IdProjeto, e.Titulo, e.Entregue)).ToList();

            return entregaViewModel;
        }
    }
}
