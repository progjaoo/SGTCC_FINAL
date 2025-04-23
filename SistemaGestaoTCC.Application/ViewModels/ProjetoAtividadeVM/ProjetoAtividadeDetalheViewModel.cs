using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM
{
    public class ProjetoAtividadeDetalheViewModel
    {
        public ProjetoAtividadeDetalheViewModel(int id, int idProjeto, string nome, string descricao, ProjetoAtividadeEnum estado, DateTime dataCriacao, int idUsuario, DuracaoAtividadeEnum duracaoEstimada, PrioridadeAtividadeEnum prioridade, DateTime? dataInicio, DateTime? dataEntrega)
        {
            Id = id;
            IdProjeto = idProjeto;
            Nome = nome;
            Descricao = descricao;
            Estado = estado;
            CriadoEm = dataCriacao;
            IdUsuario = idUsuario;
            DuracaoEstimada = duracaoEstimada;
            Prioridade = prioridade;
            DataInicio = dataInicio;
            DataEntrega = dataEntrega;
        }
        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DuracaoAtividadeEnum DuracaoEstimada { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? DataEntrega { get; set; }
        public PrioridadeAtividadeEnum Prioridade { get; set; }
        public DateTime? DataInicio { get; set; }
        public ProjetoAtividadeEnum Estado { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
