using MediatR;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Queries.Comentarios.GetAllComentsByProject
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
