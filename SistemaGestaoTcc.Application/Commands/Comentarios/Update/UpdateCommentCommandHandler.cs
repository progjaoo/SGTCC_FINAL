using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.Courses.UpdateCourse
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IProjetoComentarioRepository _projetoComentarioRepository;
        public UpdateCommentCommandHandler(IProjetoComentarioRepository projetoComentarioRepository)
        {
            _projetoComentarioRepository = projetoComentarioRepository;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comentario = await _projetoComentarioRepository.GetById(request.Id);

            comentario.UpdateComment(request.IdUsuario, request.IdProjeto, request.Comentario);

            await _projetoComentarioRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}