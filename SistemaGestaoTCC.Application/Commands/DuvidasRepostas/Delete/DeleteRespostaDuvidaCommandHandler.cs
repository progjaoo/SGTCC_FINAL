using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.DuvidasRepostas.Delete
{
    public class DeleteRespostaDuvidaCommandHandler : IRequestHandler<DeleteRespostaDuvidaCommand, Unit>
    {
        private readonly IRespostaDuvidaRepository _repository;
        public DeleteRespostaDuvidaCommandHandler(IRespostaDuvidaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteRespostaDuvidaCommand request, CancellationToken cancellationToken)
        {
            var resposta = await _repository.GetByIdAsync(request.Id);
            if (resposta == null)
                throw new Exception("Resposta não encontrada");

            await _repository.Delete(resposta.Id);
            await _repository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
