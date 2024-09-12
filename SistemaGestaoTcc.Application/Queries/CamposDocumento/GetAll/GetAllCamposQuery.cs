using MediatR;
using SistemaGestaoTcc.Application.ViewModels.CampoDocVM;

namespace SistemaGestaoTcc.Application.Queries.CamposDocumento.GetAll
{
    public class GetAllCamposQuery : IRequest<List<CampoDocumentoViewModel>> { }
}
