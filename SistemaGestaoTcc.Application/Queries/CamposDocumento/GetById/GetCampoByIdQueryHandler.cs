using MediatR;
using SistemaGestaoTCC.Application.ViewModels.CampoDocVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.CamposDocumento.GetById
{
    public class GetCampoByIdQueryHandler : IRequestHandler<GetCampoByIdQuery, CampoDocumentoViewModel>
    {
        private readonly ICampoDocumentoRepository _campoDocumentoRepository;
        public GetCampoByIdQueryHandler(ICampoDocumentoRepository campoDocumentoRepository)
        {
            _campoDocumentoRepository = campoDocumentoRepository;
        }
        public async Task<CampoDocumentoViewModel> Handle(GetCampoByIdQuery request, CancellationToken cancellationToken)
        {
            var campo = await _campoDocumentoRepository.GetByIdAsync(request.Id);

            if (campo == null) return null;

            var campoViewModel = new CampoDocumentoViewModel(
                campo.Id,
                campo.Campo,
                campo.IdCategoria);

            return campoViewModel;
        }
    }
}