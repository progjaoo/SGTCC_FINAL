using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Bibliografias.Create
{
    public class CreateBibliografiaCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Autores { get; set; }
        public string Referencia { get; set; }

    }
}
