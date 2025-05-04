using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Users.GetAllUsersByCourse
{
    public class GetAllByCourseQueryHandler : IRequestHandler<GetAllByCourseQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllByCourseQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllByCourseQuery request, CancellationToken cancellationToken)
        {
            var listUser = await _userRepository.GetAllUserByCourse(request.Query);

            var listUserViewModel = listUser
                .Select(u => new UserViewModel(u.Id, u.Nome, u.Email, u.IdCurso ?? 0, u.IdCursoNavigation.Nome, u.Papel, u.IdImagemNavigation)).ToList();

            return listUserViewModel;
        }
    }
}
