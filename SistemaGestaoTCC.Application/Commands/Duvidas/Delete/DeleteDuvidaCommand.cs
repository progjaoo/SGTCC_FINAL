using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Duvidas.Delete
{
    public class DeleteDuvidaCommand : IRequest<Unit>
    {

        public int Id { get; set; }
        public DeleteDuvidaCommand(int id)
        {
            Id = id;
        }
    }
}
