using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using System.Runtime.CompilerServices;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Delete
{
    internal class DeleteProjetoAtividadeCommandHandler : IRequestHandler<DeleteProjetoAtividadeCommand, Unit>
    {
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
        private readonly IAtividadeComentarioRepository _atividadeComentarioRepository;
        public DeleteProjetoAtividadeCommandHandler(IProjetoAtividadeRepository projetoAtividadeRepository, IAtividadeComentarioRepository atividadeComentarioRepository)
        {
            _projetoAtividadeRepository = projetoAtividadeRepository;
            _atividadeComentarioRepository = atividadeComentarioRepository;
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
