using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.ProjetoAtividades.Delete
{
    internal class DeleteProjetoAtividadeCommandHandler : IRequestHandler<DeleteProjetoAtividadeCommand, Unit>
    {
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
        public DeleteProjetoAtividadeCommandHandler(IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _projetoAtividadeRepository = projetoAtividadeRepository;
        }
        public async Task<Unit> Handle(DeleteProjetoAtividadeCommand request, CancellationToken cancellationToken)
        {
            var atividade = await _projetoAtividadeRepository.GetById(request.Id);

            if (atividade == null)
                throw new Exception("atividade não encontrada");
            
            await _projetoAtividadeRepository.DeleteAtividade(atividade.Id);
            await _projetoAtividadeRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
