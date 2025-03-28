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

            // Mantendo a propriedade Imagem do remoto
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

            // Manter DataFim como DateTime?, mas formatando quando necessário
            DataFim = dataFim;
            DataFimFormatado = dataFim.HasValue ? dataFim.Value.ToString("dd-MM-yyyy") : null;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<UserProjectDetailedViewModel> Usuarios { get; set; }
        public ICollection<TagsViewModel> Tags { get; set; }
        public ArquivoViewModel? Imagem { get; set; }

        // Mantendo a DataFim original como DateTime?
        public DateTime? DataFim { get; set; }

        // Criando uma nova propriedade para a versão formatada
        public string? DataFimFormatado { get; set; }
    }
}
