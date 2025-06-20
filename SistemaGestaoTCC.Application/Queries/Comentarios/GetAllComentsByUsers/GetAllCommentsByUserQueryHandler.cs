﻿using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Comentarios.GetAllComentsByProject
{
    public class GetAllCommentsByUserQueryHandler : IRequestHandler<GetAllCommentsByUserQuery, IEnumerable<ProjetoComentario>>
    {
        private readonly IProjetoComentarioRepository _projetoComentarioRepository;

        public GetAllCommentsByUserQueryHandler(IProjetoComentarioRepository projetoComentarioRepository)
        {
            _projetoComentarioRepository = projetoComentarioRepository;
        }
        public async Task<IEnumerable<ProjetoComentario>> Handle(GetAllCommentsByUserQuery request, CancellationToken cancellationToken)
        {
            var comentarios = await _projetoComentarioRepository.GetAllCommentsByProject(request.IdUsuario);
            return comentarios;
        }
    }

}
