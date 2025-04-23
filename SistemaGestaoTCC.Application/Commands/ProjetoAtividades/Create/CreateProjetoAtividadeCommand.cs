using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Create
{
    public class CreateProjetoAtividadeCommand : IRequest<int>
    {
        public int IdProjeto { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DuracaoAtividadeEnum DuracaoEstimada { get; set; }
        public PrioridadeAtividadeEnum Prioridade { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataEntrega { get; set; }
    }
}
