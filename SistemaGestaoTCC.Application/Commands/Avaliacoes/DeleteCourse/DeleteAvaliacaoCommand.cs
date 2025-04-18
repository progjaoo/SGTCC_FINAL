using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Avaliacoes.Delete
{
    public class DeleteAvaliacaoCommand : IRequest<Unit>
    {
        public int IdProjeto { get; set; }
        public int IdUsuario { get; set; }

        public DeleteAvaliacaoCommand(int idProjeto, int idUsuario)
        {
            IdProjeto = idProjeto;
            IdUsuario = idUsuario;
        }
    }
}
