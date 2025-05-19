using MediatR;

namespace SistemaGestaoTCC.Application.Queries.Users.DefinirCurso
{
    public class DefinirCursoCommand : IRequest<Unit>
    {
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }

        public DefinirCursoCommand(int idUsuario, int idCurso)
        {
            IdUsuario = idUsuario;
            IdCurso = idCurso;
        }
    }
}
