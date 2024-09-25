using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.Projects.FinalizarProjetos
{
    public class FinalizarProjectCommandHandler : IRequestHandler<FinalizarProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public FinalizarProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(FinalizarProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.Id);

            if (project == null)
                throw new Exception("Projeto não encontrado");

            await _projectRepository.Finalizar(project.Id);
            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
