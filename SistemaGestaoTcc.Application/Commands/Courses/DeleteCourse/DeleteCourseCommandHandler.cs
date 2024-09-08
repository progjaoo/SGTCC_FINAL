using MediatR;
using SistemaGestaoTcc.Application.Commands.Projects.DeleteProject;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.Comentarios.Delete
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Unit>
    {
        private readonly ICourseRepository _courseRepository;
        public DeleteCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var comentario = await _courseRepository.GetById(request.Id);

            await _courseRepository.DeleteCourse(comentario.Id);

            await _courseRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
