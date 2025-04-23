using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.UpdateSeminariosProjeto
{
    public class UpdateSeminarioProjetoCommandHandler : IRequestHandler<UpdateSeminarioProjetoCommand, Unit>
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public UpdateSeminarioProjetoCommandHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }
        public async Task<Unit> Handle(UpdateSeminarioProjetoCommand request, CancellationToken cancellationToken)
        {
            var seminario = await _seminarioRepository.GetSeminarioProjetoByIdAsync(request.Id);

            if (seminario == null)
            {
                throw new Exception("Busca não encontrada");
            }
            seminario.UpdateSeminarioProjeto(request.IdSeminario, request.IdProjeto);
            await _seminarioRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
