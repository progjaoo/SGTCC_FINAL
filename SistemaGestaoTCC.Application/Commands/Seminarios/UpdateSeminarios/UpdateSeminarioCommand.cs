using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.UpdateSeminarios
{
    public class UpdateSeminarioCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Requisitos { get; set; }
        public DateTime Data { get; set; }
    }
}
