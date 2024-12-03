using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Projects.FinalizarProjetos
{
    public class FinalizarProjectCommand : IRequest<Unit>
    {
        public FinalizarProjectCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public DateTime DataFim { get; set; }
    }
}
