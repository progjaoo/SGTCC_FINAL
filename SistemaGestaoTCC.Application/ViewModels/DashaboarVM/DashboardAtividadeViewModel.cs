namespace SistemaGestaoTCC.Application.ViewModels.DashaboarVM
{
    public class DashboardAtividadeViewModel
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Prioridade { get; set; }
        public string Estado { get; set; }
        public DateTime? DataEntrega { get; set; }
        public bool Atrasada { get; set; }
        public List<string> Comentarios { get; set; }
    }
}
