using MediatR;
using SistemaGestaoTcc.Application.ViewModels.CampoDocVM;

namespace SistemaGestaoTcc.Application.Queries.CamposDocumento.GetById
{
    public class GetCampoByIdQuery : IRequest<CampoDocumentoViewModel>
    {
        public GetCampoByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
