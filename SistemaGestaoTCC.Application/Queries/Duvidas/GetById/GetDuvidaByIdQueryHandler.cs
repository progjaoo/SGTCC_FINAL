using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetById
{
    public class GetDuvidaByIdQueryHandler : IRequestHandler<GetDuvidaByIdQuery, DuvidasViewModel>
    {
        private readonly IDuvidaRepository _duvidaRepository;

        public GetDuvidaByIdQueryHandler(IDuvidaRepository duvidaRepository)
        {
            _duvidaRepository = duvidaRepository;
        }

        public async Task<DuvidasViewModel> Handle(GetDuvidaByIdQuery request, CancellationToken cancellationToken)
        {
            var duvida = await _duvidaRepository.GetByIdAsync(request.Id);
            if (duvida == null)
            {
                throw new Exception("Dúvida não encontrada");
            }
            var duvidasViewModel = new DuvidasViewModel(duvida.Id, duvida.IdProjeto, duvida.IdUsuario, duvida.Texto,
                duvida.Visibilidade, duvida.Atendida, duvida.CriadoEm, duvida.IdUsuarioNavigation.Nome);

            return duvidasViewModel;
        }
    }
}
