using MediatR;
using SistemaGestaoTCC.Application.ViewModels.CampoDocVM;

namespace SistemaGestaoTCC.Application.Queries.CamposDocumento.GetAll
{
    public class GetAllCamposQuery : IRequest<List<CampoDocumentoViewModel>> { }
}
