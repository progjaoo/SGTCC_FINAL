using MediatR;
using SistemaGestaoTCC.Application.Commands.Projects.DeleteProject;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Comentarios.Delete
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
            var curso = await _courseRepository.GetById(request.Id);

            if (curso == null)
                throw new Exception("curso não encontrado");

            await _courseRepository.DeleteCourse(curso.Id);

            await _courseRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
