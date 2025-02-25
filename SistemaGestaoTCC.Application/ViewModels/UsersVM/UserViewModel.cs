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

        public UserViewModel(int? id, string? nome, string email, int idCurso, PapelEnum papel, string nomeCurso)
        {
            Id = id;
            Nome = nome;
            Email = email;
            IdCurso = idCurso;
            Papel = papel;
            NomeCurso = nomeCurso;
        }

        public string? Imagem { get; set; }
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string Email { get; set; }
        public int IdCurso { get; set; }
        public PapelEnum Papel { get; set; }
        public string NomeCurso { get; set; }
    }
}
