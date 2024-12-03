using MediatR;
using SistemaGestaoTCC.Application.ViewModels.UsersVM;

namespace SistemaGestaoTCC.Application.Queries.UsuariosProjeto
{
    public class GetUserProjectByIdQuery : IRequest<UserProjectViewModel>
    {
        public GetUserProjectByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}