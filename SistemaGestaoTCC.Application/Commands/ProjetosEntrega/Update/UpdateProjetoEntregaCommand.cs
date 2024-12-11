using MediatR;

namespace SistemaGestaoTCC.Application.Commands.ProjetosEntrega.Update
{
    public class UpdateProjetoEntregaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime? DataEnvio { get; set; }
        public bool Entregue { get; set; }
    }
}