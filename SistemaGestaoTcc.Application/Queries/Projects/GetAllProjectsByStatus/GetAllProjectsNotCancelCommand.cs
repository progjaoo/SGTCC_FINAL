using MediatR;
using SistemaGestaoTcc.Application.ViewModels;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Queries.Projects.GetAllProjectsByStatus
{
    public class GetAllProjectsNotCancelCommand : IRequest<List<ProjectViewModel>>
    {
        public int IdUsuario { get; }

        public GetAllProjectsNotCancelCommand(int idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}