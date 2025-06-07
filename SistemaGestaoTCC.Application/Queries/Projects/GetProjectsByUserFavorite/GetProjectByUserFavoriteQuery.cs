using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUserFavorite
{
    public class GetProjectByUserFavoriteQuery : IRequest<List<ProjectFilterViewModel>>
    {
        public GetProjectByUserFavoriteQuery(int idUsuario)
        {
           IdUsuario = idUsuario;
        }   
        public int IdUsuario { get; set; }
    }
}
