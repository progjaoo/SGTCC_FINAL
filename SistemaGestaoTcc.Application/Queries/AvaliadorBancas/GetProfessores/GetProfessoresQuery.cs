using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.Queries.AvaliadorBancas.GetProfessores
{
    public class GetProfessoresQuery : IRequest<List<UserRoleViewModel>>
    {

    }
}
