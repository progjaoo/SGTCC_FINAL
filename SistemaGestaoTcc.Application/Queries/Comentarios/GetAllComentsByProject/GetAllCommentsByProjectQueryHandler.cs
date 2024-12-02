using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Comentarios.GetAllComentsByProject
{
    public class GetAllCommentsByProjectQueryHandler : IRequestHandler<GetAllCommentsByProjectQuery, IEnumerable<ProjetoComentario>>
    {
        private readonly IProjetoComentarioRepository _projetoComentarioRepository;

        public GetAllCommentsByProjectQueryHandler(IProjetoComentarioRepository projetoComentarioRepository)
        {
            _projetoComentarioRepository = projetoComentarioRepository;
        }
        public async Task<IEnumerable<ProjetoComentario>> Handle(GetAllCommentsByProjectQuery request, CancellationToken cancellationToken)
        {
            var comentarios = await _projetoComentarioRepository.GetAllCommentsByProject(request.IdProjeto);
            return comentarios;
        }
    }

}
