using MediatR;

namespace SistemaGestaoTCC.Application.Commands.NotasFinalAluno.Create
{
    public class CreateNotaFinalAlunoCommand : IRequest<int>
    {
        public int IdAvaliadorBanca { get; set; }
        public int IdAluno { get; set; }
        public int Nota { get; set; }
    }
}
