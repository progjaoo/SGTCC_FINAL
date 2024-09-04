using MediatR;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.Projects.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public int IdCurso { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Justificativa { get; set; }
    }
}
