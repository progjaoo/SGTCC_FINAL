using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AtividadesComentarioVM;

namespace SistemaGestaoTCC.Application.Queries.AtividadesComentários.GetById
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
