using MediatR;
using SistemaGestaoTCC.Application.ViewModels.NotaFinalVM;

namespace SistemaGestaoTCC.Application.Queries.NotaFinalAluno.GetById
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
