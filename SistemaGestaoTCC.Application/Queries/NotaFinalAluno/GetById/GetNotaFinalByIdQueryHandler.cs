using MediatR;
using SistemaGestaoTCC.Application.ViewModels.NotaFinalVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.NotaFinalAluno.GetById
{
    public class GetNotaFinalByIdQueryHandler : IRequestHandler<GetNotaFinalByIdQuery, NotaFinalViewModel>
    {
        private readonly INotaFinalAlunoRepository _notaFinalAlunoRepository;
        public GetNotaFinalByIdQueryHandler(INotaFinalAlunoRepository notaFinalAlunoRepository)
        {
            _notaFinalAlunoRepository = notaFinalAlunoRepository;
        }
        public async Task<NotaFinalViewModel> Handle(GetNotaFinalByIdQuery request, CancellationToken cancellationToken)
        {
            var nota = await _notaFinalAlunoRepository.GetByIdAsync(request.Id);

            if (nota == null)
                return null;

            var notaViewModel = new NotaFinalViewModel(
                nota.IdAluno,
                nota.Nota,
                nota.IdAlunoNavigation.Nome);

            return notaViewModel;
        }
    }
}