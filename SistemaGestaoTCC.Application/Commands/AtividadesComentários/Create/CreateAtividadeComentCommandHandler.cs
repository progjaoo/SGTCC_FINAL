using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.AtividadesComentários.Create
{
    public class CreateAtividadeComentCommandHandler : IRequestHandler<CreateAtividadeComentCommand, int>
    {
        private readonly IAtividadeComentarioRepository _atividadeComentarioRepository;
        public CreateAtividadeComentCommandHandler(IAtividadeComentarioRepository atividadeComentarioRepository)
        {
            _atividadeComentarioRepository = atividadeComentarioRepository;
        }
        public async Task<int> Handle(CreateAtividadeComentCommand request, CancellationToken cancellationToken)
        {
            var atividade = new AtividadeComentario(request.IdUsuario, request.IdAtividade, request.Comentario);

            await _atividadeComentarioRepository.AddASync(atividade);
            await _atividadeComentarioRepository.SaveChangesAsync();

            return atividade.Id;
        }
    }
}
