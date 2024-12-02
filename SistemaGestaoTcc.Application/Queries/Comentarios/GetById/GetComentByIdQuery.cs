using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ComentariosVM;

namespace SistemaGestaoTCC.Application.Queries.Comentarios.GetById
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
