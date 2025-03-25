using MediatR;
using SistemaGestaoTCC.Application.Helpers;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

//WARN Por algum motivo a pasta com nome Arquivos tava dando erro
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
            var extensao = Path.GetExtension(request.File.FileName);
            var arquivo = new Arquivo(request.File.FileName, request.Diretorio, (int)request.File.Length, extensao);

            var novoArquivo = await _arquivoRepository.AddAsync(arquivo);

            await ArquivoHelper.SalvarArquivo(request.File, request.Diretorio, novoArquivo.Id);

            return arquivo.Id;
        }
    }
}
