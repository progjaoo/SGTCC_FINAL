using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.NotaDocumentos.Create
{
    public class CreateNotaDocCommandHandler : IRequestHandler<CreateNotaDocCommand, int>
    {
        private readonly INotasDocumentoAlunoRepository _notasDocumentoAlunoRepository;
        public CreateNotaDocCommandHandler(INotasDocumentoAlunoRepository notasDocumentoAlunoRepository)
        {
            _notasDocumentoAlunoRepository = notasDocumentoAlunoRepository;
        }
        public async Task<int> Handle(CreateNotaDocCommand request, CancellationToken cancellationToken)
        {
            var nota = new NotaDocumentoAluno(request.IdAvaliadorBanca, request.IdCampo, request.IdAluno,request.Nota, request.Tipo);

            await _notasDocumentoAlunoRepository.AddAsync(nota);
            await _notasDocumentoAlunoRepository.SaveChangesAsync();

            return nota.Id;
        }
    }
}
