using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.CreateSeminariosProjeto
{
    public class CreateSeminarioProjetoCommand : IRequest<int>
    {
        public int IdSeminario { get; set; }
        public int IdProjeto { get; set; }
    }
}
