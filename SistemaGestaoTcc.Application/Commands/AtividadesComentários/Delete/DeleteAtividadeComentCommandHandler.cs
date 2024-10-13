using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.AtividadesComentários.Delete
{
    public class DeleteAtividadeComentCommandHandler : IRequestHandler<DeleteAtividadeComentCommand, Unit>
    {
        private readonly IAtividadeComentarioRepository _atividadeComentarioRepository;
        public DeleteAtividadeComentCommandHandler(IAtividadeComentarioRepository atividadeComentarioRepository)
        {
            _atividadeComentarioRepository = atividadeComentarioRepository;
        }
        public async Task<Unit> Handle(DeleteAtividadeComentCommand request, CancellationToken cancellationToken)
        {
            var atividade = await _atividadeComentarioRepository.GetById(request.Id);

            if (atividade == null)
                throw new Exception("Comentário em atividade não encontrado");

            await _atividadeComentarioRepository.Delete(atividade.Id);
            await _atividadeComentarioRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
