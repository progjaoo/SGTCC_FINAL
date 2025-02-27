using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.ArquivoVM
{
    public class ArquivoViewModel
    {
        public ArquivoViewModel(
            int id,
            string nomeOriginal,
            string diretorio,
            int tamanho,
            string extensao,
            DateTime criadoEm,
            DateTime? editadoEm,
            int? idProjetoArquivo,
            int? idImagemUsuario,
            int? idImagemProjeto,
            int? idImagemCurso
            )
        {
            Id = id;
            NomeOriginal = nomeOriginal;
            Diretorio = diretorio;
            Tamanho = tamanho;
            Extensao = extensao;
            CriadoEm = criadoEm;
            EditadoEm = editadoEm;

            IdProjetoArquivo = idProjetoArquivo;
            IdImagemUsuario = idImagemUsuario;
            IdImagemProjeto = idImagemProjeto;
            IdImagemCurso = idImagemCurso;
        }
        public int Id { get; set; }
        public int? IdProjetoArquivo { get; set; }
        public int? IdImagemUsuario { get; set; }
        public int? IdImagemProjeto { get; set; }
        public int? IdImagemCurso { get; set; }
        public string NomeOriginal { get; set; }
        public string Diretorio { get; set; }
        public string Extensao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? EditadoEm { get; set; }
        public int Tamanho { get; set; }
    }
}
