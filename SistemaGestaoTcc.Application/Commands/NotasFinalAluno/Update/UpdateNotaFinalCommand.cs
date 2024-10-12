using MediatR;

namespace SistemaGestaoTcc.Application.Commands.NotasFinalAluno.Update
{
    public class UpdateNotaFinalCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdAvaliadorBanca { get; set; }
        public int IdAluno { get; set; }
        public int Nota { get; set; }
    }
}
