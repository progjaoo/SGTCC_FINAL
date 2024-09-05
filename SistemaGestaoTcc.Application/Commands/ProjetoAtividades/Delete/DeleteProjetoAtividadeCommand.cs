using MediatR;

namespace SistemaGestaoTcc.Application.Commands.ProjetoAtividades.Delete
{
    public class DeleteProjetoAtividadeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteProjetoAtividadeCommand(int id)
        {
            Id = id;
        }
    }
}
