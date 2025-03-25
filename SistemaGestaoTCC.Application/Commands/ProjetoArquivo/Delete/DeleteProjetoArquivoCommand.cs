using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SistemaGestaoTCC.Application.Commands.ProjetoArquivo.Delete
{
    public class DeleteProjetoArquivoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
