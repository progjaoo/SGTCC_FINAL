using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.CreateSeminarios
{
    public class CreateSeminarioCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public string Requisitos { get; set; }
        public DateTime Data { get; set; }
    }
}
