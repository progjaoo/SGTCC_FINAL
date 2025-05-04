using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Users.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetById(request.Id);

            if (user == null)
            {
                return null;
            }
            Console.WriteLine($"Usuário: {user.Nome}, CursoId: {user.IdCurso}, CursoNome: {user.IdCursoNavigation?.Nome}");

            string nomeCurso = user.IdCursoNavigation?.Nome ?? "Curso não encontrado";

            var userViewModel = new UserViewModel(user.Id, user.Nome, user.Email, user.IdCurso ?? 0, nomeCurso, user.Papel, user.IdImagemNavigation);

            return userViewModel;

        }
    }
}