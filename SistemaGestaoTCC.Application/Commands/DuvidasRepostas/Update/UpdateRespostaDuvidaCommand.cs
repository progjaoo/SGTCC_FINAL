using MediatR;

namespace SistemaGestaoTCC.Application.Commands.DuvidasRepostas.Update
{
    public class UpdateRespostaDuvidaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdDuvida { get; set; }
        public int IdUsuario { get; set; }
        public string Texto { get; set; }
    }
}
