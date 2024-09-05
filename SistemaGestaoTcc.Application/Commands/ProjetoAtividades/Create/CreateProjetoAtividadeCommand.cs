using MediatR;

namespace SistemaGestaoTcc.Application.Commands.ProjetoAtividades.Create
{
    public class CreateProjetoAtividadeCommand : IRequest<int>
    {
        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
