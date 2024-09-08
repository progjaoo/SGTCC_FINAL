using MediatR;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Queries.Comentarios.GetAllComentsByProject
{
    public class GetAllCommentsByProjectQuery : IRequest<IEnumerable<ProjetoComentario>>
    {
        public int IdProjeto { get; }

        public GetAllCommentsByProjectQuery(int projetoId)
        {
            IdProjeto = projetoId;
        }
    }
}