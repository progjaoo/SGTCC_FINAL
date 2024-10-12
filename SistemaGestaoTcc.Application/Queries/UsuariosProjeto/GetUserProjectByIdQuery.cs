using MediatR;
using SistemaGestaoTcc.Application.ViewModels.UsersVM;

namespace SistemaGestaoTcc.Application.Queries.UsuariosProjeto
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