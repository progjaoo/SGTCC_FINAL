using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.UsersVM
{
    public class UsersAndFunctionViewModel
    {
        public UsersAndFunctionViewModel(int? id, string? nome, string email, PapelEnum papel, FuncaoEnum funcao)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Papel = papel;
            Funcao = funcao;
        }

        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string Email { get; set; }
        public PapelEnum Papel { get; set; }
        public FuncaoEnum Funcao { get; set; }
    }
}
