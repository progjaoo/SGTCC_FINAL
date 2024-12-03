using MediatR;

namespace SistemaGestaoTCC.Application.Commands.AtividadesComentários.Update
{
    public class UpdateAtividadeComentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdAtividade { get; set; }
        public string Comentario { get; set; }
    }
}
