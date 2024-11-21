namespace SistemaGestaoTcc.Core.Models
{
    public partial class AtividadeComentario //FALTA IMPLEMENTAR AINDA
    {
        public AtividadeComentario(int idUsuario, int idAtividade, string comentario)
        {
            IdUsuario = idUsuario;
            IdAtividade = idAtividade;
            Comentario = comentario;

            CriadoEm = DateTime.Now;
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; } 
        public int IdAtividade { get; set; } 
        public string Comentario { get; set; } 
        public DateTime CriadoEm { get; set; } 
        public DateTime? EditadoEm { get; set; } 
        public virtual Usuario IdUsuarioNavigation { get; set; } 
        public virtual ProjetoAtividade IdAtividadeNavigation { get; set; }

        public void UpdateAtividadeComentario(int idUsuario, int idAtividade, string comentario)
        {
            IdUsuario = idUsuario;
            IdAtividade = idAtividade;
            Comentario = comentario;

            EditadoEm = DateTime.Now;
        }
    }
}
