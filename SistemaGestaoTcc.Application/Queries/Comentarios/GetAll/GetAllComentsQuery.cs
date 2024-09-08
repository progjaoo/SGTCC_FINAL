using MediatR;
using SistemaGestaoTcc.Application.ViewModels.ComentariosVM;

namespace SistemaGestaoTcc.Application.Queries.Comentarios.GetAll
{
    public class GetAllComentsQuery : IRequest<List<ComentarioViewModel>> { }
}
