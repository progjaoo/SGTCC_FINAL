using MediatR;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.IniciarAtividade
{
    public class StartAtividadeCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public StartAtividadeCommand(int id)
        {
            Id = id;
        }
    }
}
