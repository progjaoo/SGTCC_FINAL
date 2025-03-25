using MediatR;
using Microsoft.AspNetCore.Http;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.Arquivos.Update
{
    public class UpdateArquivosCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required IFormFile File { get; set; }
        public required string Diretorio { get; set; }
    }
}
