using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

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

            if (request.Tags != null && request.Tags.Any())
            {
                foreach (var tagViewModel in request.Tags)
                {
                    bool tagExists = project.ProjetoTags
                        .Any(t => t.Nome.Equals(tagViewModel.Nome, StringComparison.OrdinalIgnoreCase));

                    if (!tagExists)
                    {
                        var tag = new ProjetoTag
                        {
                            Nome = tagViewModel.Nome,
                            IdProjetoNavigation = project
                        };
                        project.ProjetoTags.Add(tag);
                    }
                }
            }
            project.Update(request.Nome, request.Descricao, request.Justificativa);

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
