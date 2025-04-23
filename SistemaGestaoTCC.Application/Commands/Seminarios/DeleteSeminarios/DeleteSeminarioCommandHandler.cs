using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.DeleteSeminarios
{
    public class DeleteSeminarioCommandHandler : IRequestHandler<DeleteSeminarioCommand, Unit>
    {
        private readonly ISeminarioRepository _seminarioRepository;

        public DeleteSeminarioCommandHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }

        public async Task<Unit> Handle(DeleteSeminarioCommand request, CancellationToken cancellationToken)
        {
            var seminario = await _seminarioRepository.GetById(request.Id);

            if (seminario == null)
            {
                throw new Exception("Seminário não encontrado");
            }
            await _seminarioRepository.Delete(seminario.Id);
            await _seminarioRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
