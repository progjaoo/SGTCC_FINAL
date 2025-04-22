namespace SistemaGestaoTCC.Application.ViewModels.BibliografiaVM
{
    public class BibliografiaDetalheViewModel
    {
        public BibliografiaDetalheViewModel(int idUsuario, int idProjeto, string autores, string referencia, DateTime? acessadoEm, DateTime criadoEm, DateTime? editadoEm)
        {
            IdUsuario = idUsuario;
            IdProjeto = idProjeto;
            Autores = autores;
            Referencia = referencia;
            AcessadoEm = acessadoEm;
            CriadoEm = criadoEm;
            EditadoEm = editadoEm;
        }
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Autores { get; set; }
        public string Referencia { get; set; }
        public DateTime? AcessadoEm { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? EditadoEm { get; set; }
    }
}
