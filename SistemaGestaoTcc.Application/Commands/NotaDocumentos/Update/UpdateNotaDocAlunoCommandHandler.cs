using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.NotaDocumentos.Update
{
    public class UpdateNotaDocAlunoCommandHandler : IRequestHandler<UpdateNotaDocAlunoCommand, Unit>
    {
        private readonly INotasDocumentoAlunoRepository _notasDocumentoAlunoRepository;
        public UpdateNotaDocAlunoCommandHandler(INotasDocumentoAlunoRepository notasDocumentoAlunoRepository)
        {
            _notasDocumentoAlunoRepository = notasDocumentoAlunoRepository;
        }
        public async Task<Unit> Handle(UpdateNotaDocAlunoCommand request, CancellationToken cancellationToken)
        {
            var nota = await _notasDocumentoAlunoRepository.GetByIdAsync(request.Id);

            nota.UpdateNotaDocumento(request.IdAvaliadorBanca, request.IdCampo, request.IdAluno, request.Nota, request.Tipo);
            
            await _notasDocumentoAlunoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
