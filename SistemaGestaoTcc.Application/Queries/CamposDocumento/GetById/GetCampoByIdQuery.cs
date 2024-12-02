using MediatR;
using SistemaGestaoTCC.Application.ViewModels.CampoDocVM;

namespace SistemaGestaoTCC.Application.Queries.CamposDocumento.GetById
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
