namespace SistemaGestaoTCC.Core.Models
{
    public partial class ProjetoEntregaProjeto
    {
        public ProjetoEntregaProjeto(int idEntrega, int idProjeto)
        {
            IdEntrega = idEntrega;
            IdProjeto = idProjeto;
        }

        public int Id { get; set; }
        public int IdEntrega { get; set; }
        public int IdProjeto { get; set; }
        public virtual ProjetoEntrega IdEntregaNavigation { get; set; }
        public virtual Projeto IdProjetoNavigation { get; set; }
    }
}