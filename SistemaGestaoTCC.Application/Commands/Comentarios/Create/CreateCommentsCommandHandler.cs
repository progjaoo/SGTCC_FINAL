using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using System.Runtime.CompilerServices;

namespace SistemaGestaoTCC.Application.Commands.Comentarios.Create
{
    public class CreateCommentsCommandHandler : IRequestHandler<CreateCommentsCommand, int>
    {
        private readonly IProjetoComentarioRepository _projetoComentarioRepository;
        public CreateCommentsCommandHandler(IProjetoComentarioRepository projetoComentarioRepository)
        {
            _projetoComentarioRepository = projetoComentarioRepository;
        }
        public async Task<int> Handle(CreateCommentsCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjetoComentario(request.IdUsuario, request.IdProjeto, request.Comentario);

            await _projetoComentarioRepository.AddASync(comment);
            await _projetoComentarioRepository.SaveChangesAsync();

            return comment.Id;
        }
    }
}
