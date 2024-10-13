using MediatR;

namespace SistemaGestaoTcc.Application.Commands.AtividadesComentários.Create
{
    public class CreateAtividadeComentCommand : IRequest<int>
    {
        public int IdUsuario { get; set; }
        public int IdAtividade { get; set; }
        public string Comentario { get; set; }
    }
}
