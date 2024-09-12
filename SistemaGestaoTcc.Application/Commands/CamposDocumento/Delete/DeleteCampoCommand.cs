using MediatR;

namespace SistemaGestaoTcc.Application.Commands.CamposDocumento.Delete
{
    public class DeleteCampoCommand : IRequest<bool>
    {
        public DeleteCampoCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
