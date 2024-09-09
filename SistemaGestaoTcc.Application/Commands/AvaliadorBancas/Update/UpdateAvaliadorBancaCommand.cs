using MediatR;

namespace SistemaGestaoTcc.Application.Commands.AvaliadorBancas.Update
{
    public class UpdateAvaliadorBancaCommand : IRequest<Unit>
    {
        public UpdateAvaliadorBancaCommand(int id, int idUsuario, int idBanca)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdBanca = idBanca;
        }
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdBanca { get; set; }
    }
}
