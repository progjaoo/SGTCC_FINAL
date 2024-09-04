using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
