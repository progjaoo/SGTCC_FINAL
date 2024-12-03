using MediatR;
using SistemaGestaoTCC.Application.ViewModels.NotasDocumentoVM;

namespace SistemaGestaoTCC.Application.Queries.NotaDocumentos.GetById
{
    public class GetNotaDocumentoByIdQuery : IRequest<NotaDocumentoViewModel>
    {
        public int Id { get; set; }

        public GetNotaDocumentoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
