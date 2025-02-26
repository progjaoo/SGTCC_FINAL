using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.ArquivoVM
{
    public class ArquivoViewModel
    {
        public ArquivoViewModel(
            string tipo,
            int id,
            int idExterno,
            string nomeOriginal,
            string diretorio,
            int tamanho,
            string extensao,
            DateTime criadoEm,
            DateTime? editadoEm
            )
        {
            Id = id;
            switch (tipo)
            {
                case "ProjetoArquivo":
                    IdProjetoArquivo = idExterno;
                    break;
                case "ImagemUsuario":
                    IdImagemUsuario = idExterno;
                    break;
                case "ImagemProjeto":
                    IdImagemProjeto = idExterno;
                    break;
                case "ImagemCurso":
                    IdImagemCurso = idExterno;
                    break;
            }
            NomeOriginal = nomeOriginal;
            Diretorio = diretorio;
            Tamanho = tamanho;
            Extensao = extensao;
            CriadoEm = criadoEm;
            EditadoEm = editadoEm;
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
