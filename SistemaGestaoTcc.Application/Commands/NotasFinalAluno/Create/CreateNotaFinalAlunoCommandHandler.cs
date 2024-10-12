using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.NotasFinalAluno.Create
{
    public class CreateNotaFinalAlunoCommandHandler : IRequestHandler<CreateNotaFinalAlunoCommand, int>
    {
        private readonly INotaFinalAlunoRepository _notaFinalAlunoRepository;
        public CreateNotaFinalAlunoCommandHandler(INotaFinalAlunoRepository notaFinalAlunoRepository)
        {
            _notaFinalAlunoRepository = notaFinalAlunoRepository;
        }

        public async Task<int> Handle(CreateNotaFinalAlunoCommand request, CancellationToken cancellationToken)
        {
            var nota = new NotaFinalAluno(request.IdAvaliadorBanca, request.IdAluno, request.Nota);

            await _notaFinalAlunoRepository.AddAsync(nota);
            await _notaFinalAlunoRepository.SaveChangesAsync();

            return nota.Id;
        }
    }
}