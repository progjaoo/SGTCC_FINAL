using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.Anotacoes.Delete
{
    public class DeleteAnotacaoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteAnotacaoCommand(int id)
        {
            Id = id;
        }
    }
}
