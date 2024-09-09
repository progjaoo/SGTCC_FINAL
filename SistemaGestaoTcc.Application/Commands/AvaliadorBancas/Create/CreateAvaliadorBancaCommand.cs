using MediatR;

namespace SistemaGestaoTcc.Application.Commands.AvaliadorBancas.Create
{
    public class CreateAvaliadorBancaCommand : IRequest<int>
    {

        public CreateAvaliadorBancaCommand(int idUsuario, int idBanca)
        {
            IdUsuario = idUsuario;
            IdBanca = idBanca;
        }
        public int IdUsuario { get; set; }
        public int IdBanca { get; set; }
    }
}
