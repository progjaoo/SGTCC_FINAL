using MediatR;
using SistemaGestaoTcc.Application.ViewModels.NotaFinalVM;

namespace SistemaGestaoTcc.Application.Queries.NotaFinalAluno.GetAll
{
    public class GetAllNotaFinalQuery : IRequest<List<NotaFinalViewModel>> { }
}
