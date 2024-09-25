using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.NotaDocumentos.Delete
{
    public class DeleteNotaDocAlunoCommandHandler : IRequestHandler<DeleteNotaDocAlunoCommand, Unit>
    {
        private readonly INotasDocumentoAlunoRepository _notasDocumentoAlunoRepository;
        public DeleteNotaDocAlunoCommandHandler(INotasDocumentoAlunoRepository notasDocumentoAlunoRepository)
        {
            _notasDocumentoAlunoRepository = notasDocumentoAlunoRepository;
        }
        public async Task<Unit> Handle(DeleteNotaDocAlunoCommand request, CancellationToken cancellationToken)
        {
            var nota = await _notasDocumentoAlunoRepository.GetByIdAsync(request.Id);

            if (nota == null)
                throw new Exception("nota não encontrada");

            await _notasDocumentoAlunoRepository.DeleteAsync(request.Id);
            await _notasDocumentoAlunoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}