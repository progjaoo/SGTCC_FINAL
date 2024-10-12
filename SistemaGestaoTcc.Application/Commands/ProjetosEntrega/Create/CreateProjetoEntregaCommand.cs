using MediatR;

namespace SistemaGestaoTcc.Application.Commands.ProjetosEntrega.Create
{
    public class CreateProjetoEntregaCommand : IRequest<int>
    {
        public int IdProjeto { get; set; }
        public string Titulo { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime? DataEnvio { get; set; }
        public bool Entregue { get; set; }
    }
}
