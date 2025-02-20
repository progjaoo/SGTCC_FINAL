using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.Arquivos.Create
{
    public class CreateArquivosCommand : IRequest<int>
    {
        public required string NomeOriginal { get; set; }
        public required string Diretorio { get; set; }
        public int Tamanho { get; set; }
    }
}
