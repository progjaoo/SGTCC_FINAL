using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel(string nome, string email, PapelEnum papel, int idCurso)
        {
            Nome = nome;
            Email = email;
            Papel = papel;
            IdCurso = idCurso;
        }
        public string Nome { get; set; }
        public string Email { get; set; }
        public PapelEnum Papel { get; set; }
        public int IdCurso { get; set; }
    }
}
