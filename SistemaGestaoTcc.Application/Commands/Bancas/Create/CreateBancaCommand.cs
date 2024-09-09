using MediatR;
using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.Commands.Bancas.Create
{
    public class CreateBancaCommand : IRequest<int>
    {
        public int IdProjeto { get; set; }
        public DateTime DataSeminario { get; set; }
        public ParecerBancaEnum Parecer { get; set; }
        public string ObservacaoNotaProjeto { get; set; }
        public string ObservacaoAluno { get; set; }
        public string Recomendacao { get; set; }
    }
}
