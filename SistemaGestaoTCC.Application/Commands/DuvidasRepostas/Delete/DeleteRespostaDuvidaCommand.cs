using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.DuvidasRepostas.Delete
{
    public class DeleteRespostaDuvidaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteRespostaDuvidaCommand(int id)
        {
            Id = id;
        }
    }
}
