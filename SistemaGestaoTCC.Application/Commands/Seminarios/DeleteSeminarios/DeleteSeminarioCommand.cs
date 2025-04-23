using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.DeleteSeminarios
{
    public class DeleteSeminarioCommand : IRequest<Unit>
    {
        public DeleteSeminarioCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
