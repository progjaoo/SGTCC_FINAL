namespace SistemaGestaoTCC.Application.ViewModels.AnotacaoVM
{
    public class AnotacaoViewModel
    {
        public AnotacaoViewModel(int idUsuario, int idProjeto, string titulo, string descricao)
        {
            IdUsuario = idUsuario;
            IdProjeto = idProjeto;
            Titulo = titulo;
            Descricao = descricao;
        }
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}
