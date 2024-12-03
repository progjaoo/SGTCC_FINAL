using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Update
{
    public class UpdateProjetoAtividadeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
