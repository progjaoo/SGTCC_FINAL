using MediatR;
using SistemaGestaoTCC.Application.ViewModels;

namespace SistemaGestaoTCC.Application.Queries.Users.GetUser
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public GetUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
