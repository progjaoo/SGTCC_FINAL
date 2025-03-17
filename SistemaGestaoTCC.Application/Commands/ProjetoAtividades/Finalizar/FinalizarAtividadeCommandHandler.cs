using MediatR;
using SistemaGestaoTCC.Application.Commands.Projects.FinalizarProjetos;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Finalizar
{
    public class FinalizarAtividadeCommandHandler : IRequestHandler<FinalizarAtividadeCommand, Unit>
    {
        private readonly IProjetoAtividadeRepository _projectAtividadeRepository;
        public FinalizarAtividadeCommandHandler(IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _projectAtividadeRepository = projetoAtividadeRepository;
        }

        public async Task<Unit> Handle(FinalizarAtividadeCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectAtividadeRepository.GetById(request.Id);

            if (project == null)
                throw new Exception("Atividade não encontrado");

            await _projectAtividadeRepository.FinalizarAtividade(project.Id);
            await _projectAtividadeRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
