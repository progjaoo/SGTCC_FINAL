using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Bibliografias.Update
{
    public class UpdateBibliografiaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Autores { get; set; }
        public string Referencia { get; set; }
        public DateTime? AcessadoEm { get; set; }
    }
}