using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Anotacoes.Delete
{
    public class DeleteAnotacaoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteAnotacaoCommand(int id)
        {
            Id = id;
        }
    }
}
