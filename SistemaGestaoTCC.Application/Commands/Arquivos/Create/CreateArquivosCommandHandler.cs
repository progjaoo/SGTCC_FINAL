using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Arquivos.Create
{
    public class CreateArquivosCommandHandler : IRequestHandler<CreateArquivosCommand, int>
    {
        private readonly IArquivoRepository _arquivoRepository;
        public CreateArquivosCommandHandler(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }
        public async Task<int> Handle(CreateArquivosCommand request, CancellationToken cancellationToken)
        {
            var arquivo = new Arquivo(request.NomeOriginal, request.Diretorio, request.Tamanho);

            await _arquivoRepository.AddAsync(arquivo);
            await _arquivoRepository.SaveChangesAsync();

            return arquivo.Id;
        }
    }
}
