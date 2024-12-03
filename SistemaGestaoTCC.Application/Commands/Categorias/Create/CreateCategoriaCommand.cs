using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Categorias.Create
{
    public class CreateCategoriaCommand : IRequest<int>
    {
        public string Valor { get; set; }
    }
}
