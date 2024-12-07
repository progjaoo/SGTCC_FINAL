using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.UsersVM
{
    public class UserProjectDetailedViewModel
    {
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public FuncaoEnum Funcao { get; set; }
        public required string Nome { get; set; }
        public int IdCurso { get; set; }
    }
}