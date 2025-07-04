﻿using MediatR;
using SistemaGestaoTCC.Application.ViewModels.NotasDocumentoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.NotaDocumentos.GetAll
{
    public class GetAllNotasDocumentosQueryHandler : IRequestHandler<GetAllNotasDocumentosQuery, List<NotaDocumentoViewModel>>
    {
        private readonly INotasDocumentoAlunoRepository _notaDocumentoRepository;

        public GetAllNotasDocumentosQueryHandler(INotasDocumentoAlunoRepository notaDocumentoRepository)
        {
            _notaDocumentoRepository = notaDocumentoRepository;
        }
        public async Task<List<NotaDocumentoViewModel>> Handle(GetAllNotasDocumentosQuery request, CancellationToken cancellationToken)
        {
            var notasDocumentos = await _notaDocumentoRepository.GetAllAsync();

            var notasViewModel = notasDocumentos.Select(n => new NotaDocumentoViewModel(
                n.Id,
                n.IdAvaliadorBanca,
                n.IdCampo,
                n.IdAluno,
                n.Nota,
                n.Tipo)).ToList();

            return notasViewModel;
        }
    }
}
