using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.IniciarAtividade
{
    public class StartAtividadeCommandHandler : IRequestHandler<StartAtividadeCommand, bool>
    {
        private readonly IProjetoAtividadeRepository _atividadeRepository;

        public StartAtividadeCommandHandler(IProjetoAtividadeRepository atividadeRepository)
        {
            _atividadeRepository = atividadeRepository;
        }

        public async Task<bool> Handle(StartAtividadeCommand request, CancellationToken cancellationToken)
        {
            var atividade = await _atividadeRepository.GetById(request.Id);

            if (atividade == null) return false;

            atividade.Start();

            await _atividadeRepository.AtualizarEstadoAsync(atividade);
            await _atividadeRepository.SaveChangesAsync();
            
            return true;
        }
    }
}
