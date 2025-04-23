using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.UpdateSeminariosProjeto
{
    public class UpdateSeminarioProjetoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdSeminario { get; set; }
        public int IdProjeto { get; set; }
    }
}
