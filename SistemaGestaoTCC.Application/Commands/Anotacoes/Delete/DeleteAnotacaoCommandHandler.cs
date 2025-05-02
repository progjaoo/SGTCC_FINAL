using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Anotacoes.Delete
{
    public class DeleteAnotacaoCommandHandler : IRequestHandler<DeleteAnotacaoCommand, Unit>
    {
        private readonly IAnotacaoRepository _anotacaoRepository;
        public DeleteAnotacaoCommandHandler(IAnotacaoRepository anotacaoRepository)
        {
            _anotacaoRepository = anotacaoRepository;
        }
        public async Task<Unit> Handle(DeleteAnotacaoCommand request, CancellationToken cancellationToken)
        {
            var anotacao = await _anotacaoRepository.GetById(request.Id);
            if (anotacao == null)
            {
                throw new Exception("Anotação não encontrada");
            }

            await _anotacaoRepository.DeleteAsync(anotacao.Id);
            await _anotacaoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
