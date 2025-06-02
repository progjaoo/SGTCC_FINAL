using MediatR;
using Org.BouncyCastle.Asn1.Misc;
using SistemaGestaoTCC.Application.ViewModels.CampoDocVM;

namespace SistemaGestaoTCC.Application.Queries.CamposDocumento.GetAllByCategory
{
    public class GetAllByCategoryCamposQuery : IRequest<List<CampoDocumentoViewModel>>
    {
        public int Id { get; set; }
    }
}
