using MediatR;
using SistemaGestaoTCC.Application.ViewModels.NotasDocumentoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.NotaDocumentos.GetById
{
    public class GetNotaDocumentoByIdQueryHandler : IRequestHandler<GetNotaDocumentoByIdQuery, NotaDocumentoViewModel>
    {
        private readonly INotasDocumentoAlunoRepository _notaDocumentoRepository;
        public GetNotaDocumentoByIdQueryHandler(INotasDocumentoAlunoRepository notaDocumentoRepository)
        {
            _notaDocumentoRepository = notaDocumentoRepository;
        }
        public async Task<NotaDocumentoViewModel> Handle(GetNotaDocumentoByIdQuery request, CancellationToken cancellationToken)
        {
            var notaDocumento = await _notaDocumentoRepository.GetByIdAsync(request.Id);

            if (notaDocumento == null)
            {
                return null;
            }
            var notaDocumentoViewModel = new NotaDocumentoViewModel(
                notaDocumento.Id,
                notaDocumento.IdAvaliadorBanca,
                notaDocumento.IdCampo,
                notaDocumento.IdAluno,
                notaDocumento.Nota,
                notaDocumento.Tipo);

            return notaDocumentoViewModel;
        }
    }
}
