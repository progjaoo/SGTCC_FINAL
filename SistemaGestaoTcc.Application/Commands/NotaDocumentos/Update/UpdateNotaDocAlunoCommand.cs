using MediatR;
using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.Commands.NotaDocumentos.Update
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
