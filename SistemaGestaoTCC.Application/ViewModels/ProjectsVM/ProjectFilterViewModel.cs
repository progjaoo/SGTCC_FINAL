using SistemaGestaoTCC.Application.ViewModels.TagsVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.ViewModels
{
    public class ProjectFilterViewModel
    {
        public ProjectFilterViewModel(int id, string nome, string descricao, UsuarioProjeto usuario, ProjetoTag tags, DateTime? dataFim)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Usuario = usuario;
            Tags = tags;
            DataFim = dataFim.HasValue ? dataFim.Value.ToString("dd-MM-yyyy") : null;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public UsuarioProjeto Usuario { get; set;}
        public ProjetoTag Tags { get; set; }
        public string DataFim { get; set; }
    }
}
