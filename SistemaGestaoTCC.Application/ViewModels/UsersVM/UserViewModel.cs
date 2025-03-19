using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string nome, string email, int idCurso, PapelEnum papel, Arquivo? imagem)
        {
            Id = id;
            Nome = nome;
            Email = email;
            IdCurso = idCurso;
            Papel = papel;
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
        public UserViewModel(int id, string nome, string email, int idCurso, PapelEnum papel)
        {
            Id = id;
            Nome = nome;
            Email = email;
            IdCurso = idCurso;
            Papel = papel;
        }
        public UserViewModel(string nome, string email, int idCurso)
        {
            Nome = nome;
            Email = email;
            IdCurso = idCurso;
        }
        /*public UserViewModel(int id, string nome, string email, string idCurso, PapelEnum papel)
        {
            Id = id;
            Nome = nome;
            Email = email;
            NomeCurso = idCurso;
            Papel = papel;
        }
        */
        public int? Id { get; set; }
        public ArquivoViewModel? Imagem { get; set; }
        public string? Nome { get; set; }
        public string Email { get; set; }
        public int IdCurso { get; set; }
        public PapelEnum Papel { get; set; }
        public string NomeCurso { get; set; }
    }
}
