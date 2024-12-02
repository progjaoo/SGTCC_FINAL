namespace SistemaGestaoTCC.Application.ViewModels.ComentariosVM
{
    public class ComentarioViewModel
    {
        public ComentarioViewModel(int idProjeto, string comentario)
        {
            IdProjeto = idProjeto;
            Comentario = comentario;
        }
        public ComentarioViewModel(int idUsuario, int idProjeto, string comentario)
        {
            IdUsuario = idUsuario;
            IdProjeto = idProjeto;
            Comentario = comentario;
        }

        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Comentario { get; set; }
    }
}
