namespace SistemaGestaoTcc.Application.ViewModels
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string token)
        {
            Email = email;
            Token = token;

            //UltimoAcesso = DateTime.Today;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }

        public DateTime UltimoAcesso { get; set; }
    }
}