using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Arquivos.Update
{
    public class UpdateArquivosCommandHandler : IRequestHandler<UpdateArquivosCommand, Unit>
    {
        private readonly IArquivoRepository _arquivoRepository;
        public UpdateArquivosCommandHandler(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }
        public async Task<Unit> Handle(UpdateArquivosCommand request, CancellationToken cancellationToken)
        {
            var arquivo = await _arquivoRepository.GetByIdAsync(request.Id);

            arquivo.Update(request.NomeOriginal, request.Diretorio, request.Tamanho);
            
            await _arquivoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
