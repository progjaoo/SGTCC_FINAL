using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Bancas.Delete
{
    public class DeleteBancaCommand : IRequest<Unit>
    { 

        public DeleteBancaCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
