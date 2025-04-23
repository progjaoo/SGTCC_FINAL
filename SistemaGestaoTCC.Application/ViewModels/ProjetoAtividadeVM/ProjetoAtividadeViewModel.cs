using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM
{
    public class ProjetoAtividadeViewModel
    {
        public ProjetoAtividadeViewModel(int idProjeto, string nome, DuracaoAtividadeEnum duracaoEstimada, int idUsuario, DateTime? dataEntrega)
        {
            IdProjeto = idProjeto;
            Nome = nome;
            DuracaoEstimada = duracaoEstimada;
            IdUsuario = idUsuario;
            DataEntrega = dataEntrega;
        }

        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public DuracaoAtividadeEnum DuracaoEstimada { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? DataEntrega { get; set; }
    }
}
