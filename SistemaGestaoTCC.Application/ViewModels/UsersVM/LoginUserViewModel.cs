using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string token, int idUsuario, int? idCurso, PapelEnum papel)
        {
            Email = email;
            Token = token;
            IdUsuario = idUsuario;
            IdCurso = idCurso;
            Papel = papel;

            //UltimoAcesso = DateTime.Today;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
        public int IdUsuario { get; private set; }
        public int? IdCurso { get; private set; }
        public PapelEnum Papel { get; private set; }
    }
}