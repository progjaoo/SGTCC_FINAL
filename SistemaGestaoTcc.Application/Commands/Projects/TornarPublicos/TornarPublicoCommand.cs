using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.Commands.Projects.TornarPublicos
{
    public class TornarPublicoCommand : IRequest<Unit>
    {
        public TornarPublicoCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
