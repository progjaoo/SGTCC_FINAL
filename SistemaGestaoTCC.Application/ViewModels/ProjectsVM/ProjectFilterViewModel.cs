using SistemaGestaoTCC.Application.ViewModels.TagsVM;
using SistemaGestaoTCC.Application.ViewModels.UsersVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.ViewModels
{
    public class ProjectFilterViewModel
    {
        public ProjectFilterViewModel(int id, string nome, string descricao, ICollection<UsuarioProjeto> usuario, ICollection<ProjetoTag> tags, DateTime? dataFim)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Usuarios = usuario.Select(u => new UserProjectDetailedViewModel
            {
                IdUsuario = u.IdUsuario,
                IdProjeto = u.IdProjeto,
                Funcao = u.Funcao,
                Nome = u.IdUsuarioNavigation.Nome,
                IdCurso = u.IdUsuarioNavigation.IdCurso
            }).ToList();
            Tags = tags.Select(projetoTag => new TagsViewModel
            {
                Nome = projetoTag.Nome
            }).ToList();
            DataFim = dataFim.HasValue ? dataFim.Value.ToString("dd-MM-yyyy") : null;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<UserProjectDetailedViewModel> Usuarios { get; set; }
        public ICollection<TagsViewModel> Tags { get; set; }
        public string DataFim { get; set; }
    }
}
