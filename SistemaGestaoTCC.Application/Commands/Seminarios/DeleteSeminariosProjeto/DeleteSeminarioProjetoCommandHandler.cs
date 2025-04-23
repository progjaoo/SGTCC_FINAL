using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.DeleteSeminariosProjeto
{
    public class DeleteSeminarioProjetoCommandHandler : IRequestHandler<DeleteSeminarioProjetoCommand, Unit>
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public DeleteSeminarioProjetoCommandHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }
        public async Task<Unit> Handle(DeleteSeminarioProjetoCommand request, CancellationToken cancellationToken)
        {
            var seminario = await _seminarioRepository.GetByProjectAndSeminario(request.IdSeminario, request.IdProjeto);
            if (seminario == null)
            {
                throw new Exception($"O Projeto com ID {request.IdProjeto} não está vinculado ao seminario {request.IdSeminario}.");
            }
            await _seminarioRepository.DeleteSeminarioProjeto(seminario.Id);
            await _seminarioRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
