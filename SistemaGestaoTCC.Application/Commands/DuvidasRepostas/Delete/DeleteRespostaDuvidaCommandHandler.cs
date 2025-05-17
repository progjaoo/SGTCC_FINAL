using MediatR;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.DuvidasRepostas.Delete
{
    public class DeleteRespostaDuvidaCommandHandler : IRequestHandler<DeleteRespostaDuvidaCommand, Unit>
    {
        private readonly IRespostaDuvidaRepository _repository;
        private readonly IDuvidaRepository _duvidaRepository;

        public DeleteRespostaDuvidaCommandHandler(IRespostaDuvidaRepository repository, IDuvidaRepository duvidaRepository)
        {
            _repository = repository;
            _duvidaRepository = duvidaRepository;
        }

        public async Task<Unit> Handle(DeleteRespostaDuvidaCommand request, CancellationToken cancellationToken)
        {
            var resposta = await _repository.GetByIdAsync(request.Id);
            if (resposta == null)
                throw new Exception("Resposta não encontrada");

            var duvida = await _duvidaRepository.GetByIdAsync(resposta.IdDuvida);
            if (duvida == null)
                throw new Exception("Dúvida relacionada não encontrada");

            duvida.Atendida = RespotaDuvidaEnum.Nao;
            await _duvidaRepository.MarcarComoNaoAtendidaAsync(duvida.Id);

            await _repository.Delete(resposta.Id);
            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
