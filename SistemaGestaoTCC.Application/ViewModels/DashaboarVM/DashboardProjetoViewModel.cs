namespace SistemaGestaoTCC.Application.ViewModels.DashaboarVM
{
    public class DashboardProjetoViewModel
    {
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Estado { get; set; }
        public int TotalAtividades { get; set; }
        public int AtividadesConcluidas { get; set; }
        public int AtividadesAtrasadas { get; set; }
        public List<DashboardAtividadeViewModel> Atividades { get; set; }
        public List<DashboardAtividadeViewModel> ComentariosProjeto { get; set; }
        public double PercentualConcluido => TotalAtividades == 0 ? 0 : Math.Round((double)AtividadesConcluidas / TotalAtividades * 100, 2);
    }

}
