using MediatR;

namespace SistemaGestaoTCC.Application.Commands.CamposDocumento.Update
{
    public class UpdateCampoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Campo { get; set; }
        public int IdCategoria { get; set; }
    }
}
