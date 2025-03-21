using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Arquivos.Delete
{
    public class DeleteArquivosCommandHandler : IRequestHandler<DeleteArquivosCommand, Unit>
    {
        private readonly IArquivoRepository _arquivoRepository;
        public DeleteArquivosCommandHandler(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }
        public async Task<Unit> Handle(DeleteArquivosCommand request, CancellationToken cancellationToken)
        {
            await _arquivoRepository.DeleteAsync(request.Id);
            await _arquivoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}