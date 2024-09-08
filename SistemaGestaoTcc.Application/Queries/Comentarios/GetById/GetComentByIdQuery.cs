using MediatR;
using SistemaGestaoTcc.Application.ViewModels.ComentariosVM;

namespace SistemaGestaoTcc.Application.Queries.Comentarios.GetById
{
    public class GetComentByIdQuery : IRequest<ComentarioViewModel>
    {
        public GetComentByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
