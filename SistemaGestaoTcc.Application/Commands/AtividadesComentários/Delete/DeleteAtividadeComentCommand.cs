using MediatR;

namespace SistemaGestaoTCC.Application.Commands.AtividadesComentários.Delete
{
    public class DeleteAtividadeComentCommand : IRequest<Unit>
    {
        public DeleteAtividadeComentCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
