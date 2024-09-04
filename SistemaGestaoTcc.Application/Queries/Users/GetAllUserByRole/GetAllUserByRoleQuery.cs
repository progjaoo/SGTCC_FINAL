using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.Queries.Users.GetAllUserByRole
{
    public class GetAllUserByRoleQuery : IRequest<List<UserRoleViewModel>>
    {
        public GetAllUserByRoleQuery(PapelEnum papel)
        {
            Papel = papel;
        }

        public PapelEnum Papel { get; set; }
    }
}
