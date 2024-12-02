using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.NotaDocumentos.Update
{
    public class UpdateNotaDocAlunoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IdAvaliadorBanca { get; set; }
        public int IdCampo { get; set; }
        public int IdAluno { get; set; }
        public int Nota { get; set; }
        public NotaTipoEnum Tipo { get; set; }
    }
}
