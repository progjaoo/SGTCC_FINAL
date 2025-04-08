using MediatR;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Arquivos.Download
{
    public class DownloadArquivoQuery : IRequest<Arquivo> {
        public int idArquivo {get; set;}
    }
}
