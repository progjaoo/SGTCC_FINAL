using MediatR;

namespace SistemaGestaoTcc.Application.Commands.ProjetosEntrega.Delete
{
    public class DeleteProjetoEntregaCommand : IRequest<Unit>
    {
        public DeleteProjetoEntregaCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
