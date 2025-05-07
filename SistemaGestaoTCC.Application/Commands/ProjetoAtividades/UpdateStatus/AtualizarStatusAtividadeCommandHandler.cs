using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.UpdateStatus
{
    public class AtualizarStatusAtividadeCommandHandler : IRequestHandler<AtualizarStatusAtividadeCommand, bool>
    {
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
        public AtualizarStatusAtividadeCommandHandler(IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _projetoAtividadeRepository = projetoAtividadeRepository;
        }

        public async Task<bool> Handle(AtualizarStatusAtividadeCommand request, CancellationToken cancellationToken)
        {
            var atividade = await _projetoAtividadeRepository.GetById(request.IdAtividade);

            if (atividade == null)
            {
                return false;
            }

            atividade.Estado = request.NovoEstado;
            atividade.EditadoEm = DateTime.Now;

            await _projetoAtividadeRepository.AtualizarEstadoAsync(atividade);
            return true;
        }
    }
}
