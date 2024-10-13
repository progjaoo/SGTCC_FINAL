using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.AtividadesComentários.Update
{
    public class UpdateAtividadeComentCommandHandler : IRequestHandler<UpdateAtividadeComentCommand, Unit>
    {
        private readonly IAtividadeComentarioRepository _atividadeComentarioRepository;
        public UpdateAtividadeComentCommandHandler(IAtividadeComentarioRepository atividadeComentarioRepository)
        {
            _atividadeComentarioRepository = atividadeComentarioRepository;
        }
        public async Task<Unit> Handle(UpdateAtividadeComentCommand request, CancellationToken cancellationToken)
        {
            var atividade = await _atividadeComentarioRepository.GetById(request.Id);

            if (atividade == null)
                throw new Exception("Comentário em atividade não encontrado");

            atividade.UpdateAtividadeComentario(request.IdUsuario, request.IdAtividade, request.Comentario);
            await _atividadeComentarioRepository.SaveChangesAsync();    

            return Unit.Value;
        }
    }
}
