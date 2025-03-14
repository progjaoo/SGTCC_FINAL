using SistemaGestaoTCC.Application.ViewModels.TagsVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string nome, string descricao, ICollection<ProjetoTag> tags, DateTime? dataFim)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            DataFim = dataFim;

            Tags = tags.Select(projetoTag => new TagsViewModel
            {
                Nome = projetoTag.Nome,
            }).ToList();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataFim { get; set; }

        public ICollection<TagsViewModel> Tags { get; set; }
    }
}
