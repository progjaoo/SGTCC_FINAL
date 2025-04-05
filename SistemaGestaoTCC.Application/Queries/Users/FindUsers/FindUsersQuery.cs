using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Queries.Users.FindUsers
{
    public class FindUsersQuery : IRequest<List<UserRoleViewModel>>
    {
        public FindUsersQuery()
        {
            Papel = PapelEnum.Aluno;
            Nome = "";
        }
        public FindUsersQuery(PapelEnum papel, string nome)
        {
            Papel = papel;
            Nome = nome;
        }

        public PapelEnum Papel { get; set; }
        public string Nome { get; set; }
    }
}
