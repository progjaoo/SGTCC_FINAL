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
            int idExterno,
            DateTime criadoEm,
            DateTime? editadoEm = null
            )
        {
            Id = id;
            NomeOriginal = nomeOriginal;
            Diretorio = diretorio;
            Tamanho = tamanho;
            Extensao = extensao;
            CriadoEm = criadoEm;
            EditadoEm = editadoEm;

            IdExterno = idExterno;
        }
        public int Id { get; set; } 
        //Id externo = [idProjetoArquivo || idImagemUsuario || idImagemProjeto || idImagemCurso];
        public int IdExterno { get; set; }
        public string NomeOriginal { get; set; }
        public string Diretorio { get; set; }
        public string Extensao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? EditadoEm { get; set; }
        public int Tamanho { get; set; }
    }
}
