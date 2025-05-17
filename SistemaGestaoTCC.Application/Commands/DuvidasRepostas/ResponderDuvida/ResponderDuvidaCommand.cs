using MediatR;

namespace SistemaGestaoTCC.Application.Commands.DuvidasRepostas.ResponderDuvida
{
    public class ResponderDuvidaCommand : IRequest<int>
    {
        public int IdDuvida { get; set; }
        public int IdUsuario { get; set; }
        public string Texto { get; set; }
    }
}
