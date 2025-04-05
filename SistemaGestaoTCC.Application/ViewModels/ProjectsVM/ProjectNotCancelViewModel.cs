using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Application.ViewModels.TagsVM;
using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SistemaGestaoTCC.Application.ViewModels.ProjectsVM
{
    public class ProjectNotCancelViewModel
    {
        public ProjectNotCancelViewModel(int id, string nome, string descricao, ICollection<ProjetoTag> tags, DateTime? dataFim, Arquivo? imagem)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            DataFim = dataFim;

            Tags = tags.Select(projetoTag => new TagsViewModel
            {
                Nome = projetoTag.Nome,
            }).ToList();

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
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataFim { get; set; }
        public string Justificativa { get; set; }

        public ICollection<TagsViewModel> Tags { get; set; }

        public ArquivoViewModel? Imagem { get; set; }

    }
}
