using MediatR;

namespace SistemaGestaoTCC.Application.Commands.ProjetoAtividades.Finalizar
{
    public class FinalizarAtividadeCommand : IRequest<Unit>
    {
        public FinalizarAtividadeCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
