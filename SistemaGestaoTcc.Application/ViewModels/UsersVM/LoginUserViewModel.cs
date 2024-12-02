<<<<<<< HEAD
﻿namespace SistemaGestaoTCC.Application.ViewModels
=======
﻿using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.ViewModels
>>>>>>> 4865eafeceed53e3f2acb96c61f7b259be1902c0
{
    public class LoginUserViewModel
    {
        public LoginUserViewModel(string email, string token, int idUsuario, int idCurso, PapelEnum papel)
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
        public int IdCurso { get; private set; }
        public PapelEnum Papel { get; private set; }
    }
}