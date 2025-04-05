using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.UsersVM
{
    public class UserProjectDetailedViewModel
    {
        public int IdUsuario { get; set; }
        public ArquivoViewModel? Imagem { get; set; }
        public FuncaoEnum Funcao { get; set; }
        public required string Nome { get; set; }
        public int IdCurso { get; set; }
    }
}