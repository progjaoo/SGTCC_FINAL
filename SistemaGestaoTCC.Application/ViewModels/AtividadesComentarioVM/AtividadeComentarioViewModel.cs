namespace SistemaGestaoTCC.Application.ViewModels.AtividadesComentarioVM
{
    public class AtividadeComentarioViewModel
    {
        public AtividadeComentarioViewModel(int idUsuario, int idAtividade, string comentario)
        {
            IdUsuario = idUsuario;
            IdAtividade = idAtividade;
            Comentario = comentario;

        }
        public int IdUsuario { get; set; }
        public int IdAtividade { get; set; }
        public string Comentario { get; set; }

    }
}
