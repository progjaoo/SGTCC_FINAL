using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.DuvidasRepostas.Update
{
    public class UpdateRespostaDuvidaCommandHandler : IRequestHandler<UpdateRespostaDuvidaCommand, Unit>
    {
        private readonly IRespostaDuvidaRepository _respostaDuvidaRepository;
        public UpdateRespostaDuvidaCommandHandler(IRespostaDuvidaRepository respostaDuvidaRepository)
        {
            _respostaDuvidaRepository = respostaDuvidaRepository;
        }
        public async Task<Unit> Handle(UpdateRespostaDuvidaCommand request, CancellationToken cancellationToken)
        {

            var respostaDuvida = await _respostaDuvidaRepository.GetByIdAsync(request.Id);
            if (respostaDuvida == null)
                throw new Exception("Resposta não encontrada");

            respostaDuvida.Update(request.IdDuvida, request.IdUsuario, request.Texto);

            await _respostaDuvidaRepository.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}
