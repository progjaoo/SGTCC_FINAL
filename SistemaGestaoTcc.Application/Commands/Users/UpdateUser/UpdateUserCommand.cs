using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email {  get; set; }
        public required int IdCurso { get; set; }
    }
}
