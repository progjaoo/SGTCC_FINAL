using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Comentarios.Create
{
    public class CreateCommentsCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Comentario { get; set; }
    }
}
