namespace SistemaGestaoTCC.Core.Models;

public partial class ProjetoEntrega
{
    public ProjetoEntrega(int idProjeto, string titulo, DateTime dataLimite, DateTime? dataEnvio, bool entregue)
    {
        IdProjeto = idProjeto;
        Titulo = titulo;
        DataLimite = dataLimite;
        DataEnvio = dataEnvio;
        Entregue = entregue;

        CriadoEm = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public int IdProjeto { get; set; }
    public string Titulo { get; set; }
    public DateTime DataLimite { get; set; }
    public DateTime? DataEnvio { get; set; }
    public bool Entregue { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime? EditadoEm { get; set; }
    public virtual Projeto IdProjetoNavigation { get; set; }
    public virtual ICollection<ProjetoEntregaProjeto> ProjetoEntregaProjetos { get; set; } = new List<ProjetoEntregaProjeto>();


    public void UpdateEntrega( string titulo, DateTime dataLimite, DateTime? dataEnvio, bool entregue)
    {
        Titulo = titulo;
        DataLimite = dataLimite;
        DataEnvio = dataEnvio;
        Entregue = entregue;

        EditadoEm = DateTime.UtcNow;
    }
}
