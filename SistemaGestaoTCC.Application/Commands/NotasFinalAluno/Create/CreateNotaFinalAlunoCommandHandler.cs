using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.NotasFinalAluno.Create
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