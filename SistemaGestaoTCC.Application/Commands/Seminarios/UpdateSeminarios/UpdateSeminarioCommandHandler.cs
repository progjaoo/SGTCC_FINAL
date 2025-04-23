using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.UpdateSeminarios
{
    public class UpdateSeminarioCommandHandler : IRequestHandler<UpdateSeminarioCommand, Unit>
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public UpdateSeminarioCommandHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }
        public async Task<Unit> Handle(UpdateSeminarioCommand request, CancellationToken cancellationToken)
        {
            var seminario = await _seminarioRepository.GetById(request.Id);

            if (seminario == null)
            {
                throw new Exception("Seminário não encontrado");
            }
            seminario.UpdateSeminario(request.IdUsuario, request.Requisitos, request.Data);

            await _seminarioRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
