using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string nome, string descricao, string justificativa, 
            DateTime? dataInicio, DateTime? dataFim, StatusProjeto estado)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Justificativa = justificativa;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Estado = estado;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Justificativa { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public StatusProjeto Estado { get; set; }
    }
}
