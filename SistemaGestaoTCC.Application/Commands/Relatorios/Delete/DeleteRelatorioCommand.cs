using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Relatorios.Delete
{
    public class DeleteRelatorioCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteRelatorioCommand(int id)
        {
            Id = id;
        }
    }
}
