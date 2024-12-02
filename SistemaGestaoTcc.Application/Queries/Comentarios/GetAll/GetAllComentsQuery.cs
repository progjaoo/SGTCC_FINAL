using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ComentariosVM;

namespace SistemaGestaoTCC.Application.Queries.Comentarios.GetAll
{
    public class GetAllComentsQuery : IRequest<List<ComentarioViewModel>> { }
}
