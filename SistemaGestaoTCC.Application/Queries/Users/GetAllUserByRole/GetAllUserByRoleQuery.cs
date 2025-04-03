using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Queries.Users.GetAllUserByRole
{
    public class GetAllUserByRoleQuery : IRequest<List<UserViewModel>>
    {
        public GetAllUserByRoleQuery(PapelEnum papel)
        {
            Papel = papel;
        }

        public PapelEnum Papel { get; set; }
    }
}
