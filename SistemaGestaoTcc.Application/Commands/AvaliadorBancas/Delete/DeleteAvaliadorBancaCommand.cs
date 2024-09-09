using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.Commands.AvaliadorBancas.Delete
{
    public class DeleteAvaliadorBancaCommand : IRequest<Unit>
    {

        public DeleteAvaliadorBancaCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
