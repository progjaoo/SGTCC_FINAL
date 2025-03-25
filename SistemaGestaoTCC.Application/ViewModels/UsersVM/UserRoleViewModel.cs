using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel(string nome, string email, PapelEnum papel, int idCurso, int id)
        {
            Nome = nome;
            Email = email;
            Papel = papel;
            IdCurso = idCurso;
            Id = id;
        }

        public UserRoleViewModel(int id, string nome, string email, PapelEnum papel, int idCurso, string nomeCurso)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Papel = papel;
            IdCurso = idCurso;
            NomeCurso = nomeCurso;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public PapelEnum Papel { get; set; }
        public int IdCurso { get; set; }
        public string? NomeCurso { get; set; }
    }
}
