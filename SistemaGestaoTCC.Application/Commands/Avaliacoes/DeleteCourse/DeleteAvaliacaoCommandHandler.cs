using MediatR;
using SistemaGestaoTCC.Application.Commands.Projects.DeleteProject;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Avaliacoes.Delete
{
    public class DeleteAvaliacaoCommandHandler : IRequestHandler<DeleteAvaliacaoCommand, Unit>
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        public DeleteAvaliacaoCommandHandler(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public async Task<Unit> Handle(DeleteAvaliacaoCommand request, CancellationToken cancellationToken)
        {
            var avaliacao = await _avaliacaoRepository.GetAvaliacoesByProjectAndUserAsync(request.IdProjeto, request.IdUsuario);

            if (avaliacao == null)
                throw new Exception("Avaliação não encontrada");

            await _avaliacaoRepository.Remove(avaliacao);

            await _avaliacaoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
