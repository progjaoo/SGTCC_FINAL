using MediatR;

namespace SistemaGestaoTcc.Application.Commands.Categorias.Update
{
    public class UpdateCategoriaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Valor { get; set; }
    }
}
