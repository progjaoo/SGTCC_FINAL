using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.ViewModels.ProjetoEntregaVM
{
    public class ProjetoEntregaViewModel
    {
        public ProjetoEntregaViewModel(int idProjeto, string titulo, bool entregue)
        {
            IdProjeto = idProjeto;
            Titulo = titulo;
            Entregue = entregue;
        }
        public ProjetoEntregaViewModel(int id, int idProjeto, string titulo, bool entregue, DateTime dataLimite, DateTime? dataEnvio)
        {
            Id = id;
            IdProjeto = idProjeto;
            Titulo = titulo;
            Entregue = entregue;
            DataLimite = dataLimite;
            DataEnvio = dataEnvio;
        }
        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public string Titulo { get; set; }
        public bool Entregue { get; set; }
        public DateTime DataLimite { get; set; }
        public DateTime? DataEnvio { get; set; }
    }
}
