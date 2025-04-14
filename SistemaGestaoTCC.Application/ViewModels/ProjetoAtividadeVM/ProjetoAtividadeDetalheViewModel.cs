using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM
{
    public class ProjetoAtividadeDetalheViewModel
    {
        public ProjetoAtividadeDetalheViewModel(int id, int idProjeto, string nome, string descricao, ProjetoAtividadeEnum estado, DateTime dataCriacao)
        {
            Id = id;
            IdProjeto = idProjeto;
            Nome = nome;
            Descricao = descricao;
            Estado = estado;
            CriadoEm = dataCriacao;
        }
        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public ProjetoAtividadeEnum Estado { get; set; }
    }
}
