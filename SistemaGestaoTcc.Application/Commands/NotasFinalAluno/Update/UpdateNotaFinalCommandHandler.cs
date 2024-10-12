using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.NotasFinalAluno.Update
{
    public class UpdateNotaFinalCommandHandler : IRequestHandler<UpdateNotaFinalCommand, Unit>
    {
        private readonly INotaFinalAlunoRepository _notaFinalAlunoRepository;
        public UpdateNotaFinalCommandHandler(INotaFinalAlunoRepository notaFinalAlunoRepository)
        {
            _notaFinalAlunoRepository = notaFinalAlunoRepository;
        }
        public async Task<Unit> Handle(UpdateNotaFinalCommand request, CancellationToken cancellationToken)
        {
            var nota = await _notaFinalAlunoRepository.GetByIdAsync(request.Id);

            if (nota == null)
                throw new Exception("Nota não encontrada");

            await _notaFinalAlunoRepository.UpdateAsync(nota);
            await _notaFinalAlunoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
