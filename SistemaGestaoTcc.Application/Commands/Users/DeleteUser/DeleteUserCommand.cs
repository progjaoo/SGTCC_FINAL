using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
