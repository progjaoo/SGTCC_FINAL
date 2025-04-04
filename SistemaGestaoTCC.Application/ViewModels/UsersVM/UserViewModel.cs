using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string nome, string email, int idCurso, string nomeCurso, PapelEnum papel, Arquivo? imagem)
        {
            Id = id;
            Nome = nome;
            Email = email;
            IdCurso = idCurso;
            Papel = papel;
            NomeCurso = nomeCurso;

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
        }


        public UserViewModel(int? id, string? nome, string email, int idCurso, string nomeCurso, PapelEnum papel)
        {
            Id = id;
            Nome = nome;
            Email = email;
            IdCurso = idCurso;
            NomeCurso = nomeCurso;
            Papel = papel;
        }
        
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string Email { get; set; }
        public int IdCurso { get; set; }

        [JsonPropertyName("nomeCurso")]
        public string NomeCurso { get; set; }
        public PapelEnum Papel { get; set; }
        public ArquivoViewModel? Imagem { get; set; }

    }
}

        // public UserViewModel(int id, string nome, string email, int idCurso, PapelEnum papel)
        // {
        //     Id = id;
        //     Nome = nome;
        //     Email = email;
        //     IdCurso = idCurso;
        //     Papel = papel;
        // }
        // public UserViewModel(string nome, string email, int idCurso)
        // {
        //     Nome = nome;
        //     Email = email;
        //     IdCurso = idCurso;
        // }