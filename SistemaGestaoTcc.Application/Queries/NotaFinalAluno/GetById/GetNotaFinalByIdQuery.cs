using MediatR;
using SistemaGestaoTcc.Application.ViewModels.NotaFinalVM;

namespace SistemaGestaoTcc.Application.Queries.NotaFinalAluno.GetById
{
    public class GetNotaFinalByIdQuery : IRequest<NotaFinalViewModel>
    {
        public GetNotaFinalByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
