using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetAllProjectsByStatus
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