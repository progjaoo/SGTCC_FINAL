using MediatR;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Comentarios.GetAllComentsByProject
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