using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Arquivos.Download
{
    public class DownloadArquivoQueryHandler : IRequestHandler<DownloadArquivoQuery, Arquivo>
    {
        private readonly IArquivoRepository _arquivoRepository;

        public DownloadArquivoQueryHandler(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }

        public async Task<Arquivo> Handle(DownloadArquivoQuery request, CancellationToken cancellationToken)
        {
            var arquivo = await _arquivoRepository.GetByIdAsync(request.idArquivo);

            return arquivo;
        }
    }
}
