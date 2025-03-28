using SistemaGestaoTCC.Application.ViewModels.TagsVM;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.ViewModels.ProjectsVM
{
    public class ProjectsAndUserViewModel
    {
        public ProjectsAndUserViewModel(int id, string nome, string descricao, DateTime? dataFim, string justificativa, ICollection<ProjetoTag> tags, ICollection<Usuario> autores)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            DataFim = dataFim;
            Justificativa = justificativa;

            Tags = tags.Select(projetoTag => new TagsViewModel
            {
                Nome = projetoTag.Nome,
            }).ToList();

            Autores = autores.Select(autores => new UserViewModel
            {
                
                Nome = autores.Nome
                
            }).ToList();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataFim { get; set; }
        public string Justificativa { get; set; }
        public ICollection<TagsViewModel> Tags { get; set; }
        public ICollection<UserViewModel> Autores { get; set; }
        public class UserViewModel
        {
            public string Nome { get; set; }
        }
    }
}
