using MediatR;
using SistemaGestaoTCC.Application.ViewModels.NotasDocumentoVM;

namespace SistemaGestaoTCC.Application.Queries.NotaDocumentos.GetAll
{
    public class GetAllNotasDocumentosQuery : IRequest<List<NotaDocumentoViewModel>> { }
}
