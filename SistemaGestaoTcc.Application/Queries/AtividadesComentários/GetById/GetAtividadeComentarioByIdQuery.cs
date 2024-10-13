using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AtividadesComentarioVM;

namespace SistemaGestaoTcc.Application.Queries.AtividadesComentários.GetById
{
    public class GetAtividadeComentarioByIdQuery : IRequest<AtividadeComentarioViewModel>
    {
        public GetAtividadeComentarioByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
