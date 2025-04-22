using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Bibliografias.Update
{
    public class UpdateBibliografiaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateBibliografiaCommand(int id)
        {
            Id = id;
        }
    }
}