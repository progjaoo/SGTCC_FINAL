using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Application.ViewModels.TagsVM;
using SistemaGestaoTCC.Application.ViewModels.UsersVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.ViewModels
{
    public class ProjectFilterViewModel
    {
        public ProjectFilterViewModel(int id, string nome, string descricao, ICollection<UsuarioProjeto> usuario, ICollection<ProjetoTag> tags, Arquivo? imagem, DateTime? dataFim)
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
<<<<<<< HEAD
<<<<<<< HEAD
            DataFim = dataFim;
=======
=======
>>>>>>> 93fdce0a68f8dfcf20c282d75e3e3ef246a1f43b
            if (imagem != null)
            {
                Imagem = new ArquivoViewModel(
                    imagem.Id,
                    imagem.NomeOriginal,
                    imagem.Diretorio,
                    imagem.Tamanho,
                    imagem.Extensao,
                    imagem.Id,
                    imagem.CriadoEm
                );
            }
            DataFim = dataFim.HasValue ? dataFim.Value.ToString("dd-MM-yyyy") : null;
>>>>>>> 93fdce0a68f8dfcf20c282d75e3e3ef246a1f43b
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<UserProjectDetailedViewModel> Usuarios { get; set; }
        public ICollection<TagsViewModel> Tags { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
        public DateTime? DataFim { get; set; }
=======
        public ArquivoViewModel? Imagem { get; set; }
        public string? DataFim { get; set; }
>>>>>>> 93fdce0a68f8dfcf20c282d75e3e3ef246a1f43b
=======
        public ArquivoViewModel? Imagem { get; set; }
        public string? DataFim { get; set; }
>>>>>>> 93fdce0a68f8dfcf20c282d75e3e3ef246a1f43b
    }
}
