using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.Commands.Projects.TornarPublicos
{
    public class TornarPublicoCommandHandler : IRequestHandler<TornarPublicoCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        public TornarPublicoCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(TornarPublicoCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetById(request.Id);

            if (project == null)
                throw new Exception("Projeto não encontrado");

            await _projectRepository.TornarPublico(project.Id);
            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
