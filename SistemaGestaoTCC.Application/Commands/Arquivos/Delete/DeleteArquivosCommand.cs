using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Arquivos.Delete
{
    public class DeleteArquivosCommand : IRequest<Unit>
    {
        public DeleteArquivosCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
