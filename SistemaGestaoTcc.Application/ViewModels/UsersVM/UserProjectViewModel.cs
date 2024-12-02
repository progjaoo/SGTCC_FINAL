using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.UsersVM
{
    public class UserProjectViewModel
    {
        public UserProjectViewModel(int idUsuario, int idProjeto, FuncaoEnum funcao)
        {
            IdUsuario = idUsuario;
            IdProjeto = idProjeto;
            Funcao = funcao;
        }
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public FuncaoEnum Funcao { get; set; }
    }
}