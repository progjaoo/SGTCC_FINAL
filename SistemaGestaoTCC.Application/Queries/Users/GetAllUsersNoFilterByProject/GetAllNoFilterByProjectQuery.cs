using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Application.ViewModels.UsersVM;

namespace SistemaGestaoTCC.Application.Queries.Users.GetAllNoFilterByProject
{
    public class GetAllNoFilterByProjectQuery : IRequest<List<UsersAndFunctionViewModel>>
    {
        public GetAllNoFilterByProjectQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
