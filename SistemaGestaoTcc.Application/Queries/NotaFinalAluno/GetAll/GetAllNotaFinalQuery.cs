using MediatR;
using SistemaGestaoTCC.Application.ViewModels.NotaFinalVM;

namespace SistemaGestaoTCC.Application.Queries.NotaFinalAluno.GetAll
{
    public class GetAllNotaFinalQuery : IRequest<List<NotaFinalViewModel>> { }
}
