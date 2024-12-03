using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;

namespace SistemaGestaoTCC.Application.Queries.Users.GetAllUsersByCourse
{
    public class GetAllByProjectQuery : IRequest<List<UserViewModel>>
    {
        public GetAllByProjectQuery(int query)
        {
            Query = query;
        }

        public int Query { get; set; }
    }
}
