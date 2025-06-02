using MediatR;
using SistemaGestaoTCC.Application.ViewModels.CampoDocVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.CamposDocumento.GetAllByCategory
{
    public class GetAllByCategoryCamposQueryHandler : IRequestHandler<GetAllByCategoryCamposQuery, List<CampoDocumentoViewModel>>
    {
        private readonly ICampoDocumentoRepository _campoRepository;
        public GetAllByCategoryCamposQueryHandler(ICampoDocumentoRepository campoRepository)
        {
            _campoRepository = campoRepository;
        }
        public async Task<List<CampoDocumentoViewModel>> Handle(GetAllByCategoryCamposQuery request, CancellationToken cancellationToken)
        {
            var campo = await _campoRepository.GetAllByCategoryAsync(request.Id);

            var campoViewModel = campo.Select(c => new CampoDocumentoViewModel(
                c.Id,
                c.Campo,
                c.IdCategoria)).ToList();

            return campoViewModel;
        }
    }
}
