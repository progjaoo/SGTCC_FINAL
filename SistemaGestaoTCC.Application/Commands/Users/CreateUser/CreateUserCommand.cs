using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.Users.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public int? IdCurso { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public PapelEnum Papel { get; set; }
    }
}
