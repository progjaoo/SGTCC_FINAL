using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.ViewModels.NotasDocumentoVM
{
    public class NotaDocumentoViewModel
    {
        public NotaDocumentoViewModel(int id, int idAvaliadorBanca, int idCampo, int idAluno, int nota, NotaTipoEnum tipo)
        {
            Id = id;
            IdAvaliadorBanca = idAvaliadorBanca;
            IdCampo = idCampo;
            IdAluno = idAluno;
            Nota = nota;
            Tipo = tipo;
        }

        public int Id { get; set; }
        public int IdAvaliadorBanca { get; set; }
        public int IdCampo { get; set; }
        public int IdAluno { get; set; }
        public int Nota { get; set; }
        public NotaTipoEnum Tipo { get; set; }
    }
}
