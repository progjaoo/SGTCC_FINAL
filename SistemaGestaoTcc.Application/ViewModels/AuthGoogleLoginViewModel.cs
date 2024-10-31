namespace SistemaGestaoTcc.Application.ViewModels
{
    public class AuthGoogleLoginViewModel
    {
        public AuthGoogleLoginViewModel(int idCurso, string nome, string email)
        {
            IdCurso = idCurso;
            Nome = nome;
            Email = email;
        }

        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
