using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BacanVM;
using SistemaGestaoTCC.Application.ViewModels.NotaFinalVM;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.NotaFinalAluno.GetAll
{
    public class GetAllNotaFinalQueryHandler : IRequestHandler<GetAllNotaFinalQuery, List<NotaFinalViewModel>>
    {
        private readonly INotaFinalAlunoRepository _notafinaRepository;
        public GetAllNotaFinalQueryHandler(INotaFinalAlunoRepository notafinaRepository)
        {
            _notafinaRepository = notafinaRepository;
        }
        public async Task<List<NotaFinalViewModel>> Handle(GetAllNotaFinalQuery request, CancellationToken cancellationToken)
        {
            var nota = await _notafinaRepository.GetAllAsync();

            var notaViewModel = nota.Select(n => new NotaFinalViewModel(
            n.IdAluno,
            n.Nota,
            n.IdAlunoNavigation.Nome)).ToList();

            return notaViewModel;
        }
    }
}