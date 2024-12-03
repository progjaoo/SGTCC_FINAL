using MediatR;
using SistemaGestaoTCC.Application.ViewModels.CampoDocVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.CamposDocumento.GetAll
{
    public class GetAllCamposQueryHandler : IRequestHandler<GetAllCamposQuery, List<CampoDocumentoViewModel>>
    {
        private readonly ICampoDocumentoRepository _campoRepository;
        public GetAllCamposQueryHandler(ICampoDocumentoRepository campoRepository)
        {
            _campoRepository = campoRepository;
        }
        public async Task<List<CampoDocumentoViewModel>> Handle(GetAllCamposQuery request, CancellationToken cancellationToken)
        {
            var campo = await _campoRepository.GetAllAsync();

            var campoViewModel = campo.Select(c => new CampoDocumentoViewModel(
                c.Id,
                c.Campo,
                c.IdCategoria)).ToList();

            return campoViewModel;
        }
    }
}
