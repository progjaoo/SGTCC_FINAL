using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Application.ViewModels.TagsVM;
using SistemaGestaoTCC.Application.ViewModels.UsersVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(
            int id,
            string nome,
            string descricao,
            string justificativa,

            DateTime? dataInicio,
            DateTime? dataFim,
            StatusProjeto estado,
            Arquivo imagem = null,
            ICollection<ProjetoTag>? tags = null,
            ICollection<UsuarioProjeto>? usuarios = null
        )
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Justificativa = justificativa;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Estado = estado;

            if (imagem != null)
            {
                Imagem = new ArquivoViewModel(
                    imagem.Id,
                    imagem.NomeOriginal,
                    imagem.Diretorio,
                    imagem.Tamanho,
                    imagem.Extensao,
                    imagem.Id,
                    imagem.CriadoEm,
                    imagem.EditadoEm
                );
            }

            if (tags != null)
            {
                Tags = tags.Select(projetoTag => new TagsViewModel
                {
                    Nome = projetoTag.Nome
                }).ToList();
            }

            if (usuarios != null)
            {
                Usuarios = usuarios.Select(u => new UserProjectDetailedViewModel
                {
                    IdUsuario = u.IdUsuario,
                    Funcao = u.Funcao,
                    Nome = u.IdUsuarioNavigation.Nome,
                    IdCurso = u.IdUsuarioNavigation.IdCurso,
                    Imagem = u.IdUsuarioNavigation.IdImagemNavigation != null
                                    ? new ArquivoViewModel(
                                        u.IdUsuarioNavigation.IdImagemNavigation.Id,
                                        u.IdUsuarioNavigation.IdImagemNavigation.NomeOriginal,
                                        u.IdUsuarioNavigation.IdImagemNavigation.Diretorio,
                                        u.IdUsuarioNavigation.IdImagemNavigation.Tamanho,
                                        u.IdUsuarioNavigation.IdImagemNavigation.Extensao,
                                        u.IdUsuarioNavigation.IdImagemNavigation.Id,
                                        u.IdUsuarioNavigation.IdImagemNavigation.CriadoEm,
                                        u.IdUsuarioNavigation.IdImagemNavigation.EditadoEm
                                    )
                                    : null
                }).ToList();

            }
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Justificativa { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public StatusProjeto Estado { get; set; }
        public ArquivoViewModel Imagem { get; set; }
        public ICollection<TagsViewModel> Tags { get; set; }
        public ICollection<UserProjectDetailedViewModel> Usuarios { get; set; }
    }
}
