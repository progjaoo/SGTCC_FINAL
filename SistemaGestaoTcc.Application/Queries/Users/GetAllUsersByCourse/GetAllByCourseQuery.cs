using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;

namespace SistemaGestaoTCC.Application.Queries.Users.GetAllUsersByCourse
{
    public class GetAllByCourseQuery : IRequest<List<UserViewModel>>
    {
        public GetAllByCourseQuery(int query)
        {
            Query = query;
        }

        public int Query { get; set; }
    }
}
