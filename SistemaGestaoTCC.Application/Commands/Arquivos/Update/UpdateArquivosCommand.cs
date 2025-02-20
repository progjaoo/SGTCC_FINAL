using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.Arquivos.Update
{
    public class UpdateArquivosCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required string NomeOriginal { get; set; }
        public required string Diretorio { get; set; }
        public int Tamanho { get; set; }
    }
}
