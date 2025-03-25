using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.ViewModels
{
    public class CourseViewModel
    {
        public CourseViewModel(int id, string nome, string descricao, Arquivo? imagem)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
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
        public ArquivoViewModel? Imagem { get; set; }
    }
}