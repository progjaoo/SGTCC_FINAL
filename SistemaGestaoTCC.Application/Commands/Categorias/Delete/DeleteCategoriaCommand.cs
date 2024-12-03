using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.Categorias.Delete
{
    public class DeleteCategoriaCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteCategoriaCommand(int id)
        {
            Id = id;
        }
    }
}
