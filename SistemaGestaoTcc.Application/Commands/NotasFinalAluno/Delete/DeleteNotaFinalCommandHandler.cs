using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.NotasFinalAluno.Delete
{
    public class DeleteNotaFinalCommandHandler : IRequestHandler<DeleteNotaFinalCommand, Unit>
    {
        private readonly INotaFinalAlunoRepository _notaFinalAlunoRepository;
        public DeleteNotaFinalCommandHandler(INotaFinalAlunoRepository notaFinalAlunoRepository)
        {
            _notaFinalAlunoRepository = notaFinalAlunoRepository;
        }
        public async Task<Unit> Handle(DeleteNotaFinalCommand request, CancellationToken cancellationToken)
        {
            var nota = await _notaFinalAlunoRepository.GetByIdAsync(request.Id);

            if (nota == null)
                throw new Exception("Nota não encontrada");

            await _notaFinalAlunoRepository.DeleteAsync(nota.Id);
            await _notaFinalAlunoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}