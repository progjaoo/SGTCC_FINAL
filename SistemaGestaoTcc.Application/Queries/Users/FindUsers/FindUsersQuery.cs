using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.Queries.Users.FindUsers
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
