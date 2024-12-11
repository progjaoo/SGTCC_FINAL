using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.Id);

            project.Update(request.Nome, request.Descricao, request.Justificativa);

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
