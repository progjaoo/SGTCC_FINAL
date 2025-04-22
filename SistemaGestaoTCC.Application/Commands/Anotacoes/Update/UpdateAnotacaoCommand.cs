using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Anotacoes.Update
{
    public class UpdateAnotacaoCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public UpdateAnotacaoCommand(int id)
        {
            Id = id;
        }
    }
}
