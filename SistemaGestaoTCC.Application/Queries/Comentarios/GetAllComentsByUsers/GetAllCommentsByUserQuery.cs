using MediatR;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Comentarios.GetAllComentsByProject
{
    public class GetAllCommentsByUserQuery : IRequest<IEnumerable<ProjetoComentario>>
    {
        public int IdUsuario { get; }

        public GetAllCommentsByUserQuery(int userId)
        {
            IdUsuario = userId;
        }
    }
}
