using MediatR;
using SistemaGestaoTcc.Application.ViewModels.NotasDocumentoVM;

namespace SistemaGestaoTcc.Application.Queries.NotaDocumentos.GetById
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
