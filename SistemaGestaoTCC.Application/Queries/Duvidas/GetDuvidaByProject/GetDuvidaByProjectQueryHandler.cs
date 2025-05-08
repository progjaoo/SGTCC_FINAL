using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetDuvidaByProject
{
    public class GetDuvidaByProjectQueryHandler : IRequestHandler<GetDuvidaByProjectQuery, List<DuvidasViewModel>>
    {
        private readonly IDuvidaRepository _duvidaRepository;
        public GetDuvidaByProjectQueryHandler(IDuvidaRepository duvidaRepository)
        {
            _duvidaRepository = duvidaRepository;
        }
        public async Task<List<DuvidasViewModel>> Handle(GetDuvidaByProjectQuery request, CancellationToken cancellationToken)
        {
            var duvidas = await _duvidaRepository.GetByProjetoIdAsync(request.IdProjeto);

            if (duvidas == null || !duvidas.Any())
            {
                throw new Exception("Nenhuma dúvida encontrada para o projeto");
            }
            var duvidasViewModel = duvidas.Select(duvida => new DuvidasViewModel(duvida.Id, duvida.IdProjeto, duvida.IdUsuario, duvida.Texto, 
                duvida.Visibilidade, duvida.Atendida, duvida.CriadoEm, duvida.IdUsuarioNavigation.Nome)).ToList();

            return duvidasViewModel;
        }
    }
}
