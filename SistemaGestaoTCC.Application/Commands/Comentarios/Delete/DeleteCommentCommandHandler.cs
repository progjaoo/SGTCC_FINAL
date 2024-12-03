using MediatR;
using SistemaGestaoTCC.Application.Commands.Projects.DeleteProject;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Comentarios.Delete
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
    {
        private readonly IProjetoComentarioRepository _projetoComentarioRepository;
        public DeleteCommentCommandHandler(IProjetoComentarioRepository projetoComentarioRepository)
        {
            _projetoComentarioRepository = projetoComentarioRepository;
        }
        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var project = await _projetoComentarioRepository.GetById(request.Id);

            if (project == null)
                throw new Exception("projeTO não encontrado");

            await _projetoComentarioRepository.DeleteComentario(project.Id);

            await _projetoComentarioRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}