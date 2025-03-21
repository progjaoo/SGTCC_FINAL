using MediatR;
using Microsoft.AspNetCore.Http;

namespace SistemaGestaoTCC.Application.Commands.Arquivos.Create
{
    public class CreateArquivosCommand : IRequest<int>
    {
        public required IFormFile File { get; set; }
        public required string Diretorio { get; set; }
    }
}
