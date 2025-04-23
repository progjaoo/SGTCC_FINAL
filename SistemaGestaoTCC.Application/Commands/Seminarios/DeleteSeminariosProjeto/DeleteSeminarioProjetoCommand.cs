using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.DeleteSeminariosProjeto
{
    public class DeleteSeminarioProjetoCommand : IRequest<Unit>
    {
        public DeleteSeminarioProjetoCommand(int idSeminario, int idProjeto)
        {
            IdSeminario = idSeminario;
            IdProjeto = idProjeto;
        }

        public int IdSeminario { get; set; }
        public int IdProjeto { get; set; }
    }
}
