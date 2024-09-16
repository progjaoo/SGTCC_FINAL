using MediatR;
using SistemaGestaoTcc.Application.ViewModels.NotasDocumentoVM;

namespace SistemaGestaoTcc.Application.Queries.NotaDocumentos.GetAll
{
    public class GetAllNotasDocumentosQuery : IRequest<List<NotaDocumentoViewModel>> { }
}
