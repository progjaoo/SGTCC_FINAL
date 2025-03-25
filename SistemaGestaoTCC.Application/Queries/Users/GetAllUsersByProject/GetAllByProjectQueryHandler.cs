using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Users.GetAllUsersByCourse
{
    public class GetAllByProjectQueryHandler : IRequestHandler<GetAllByProjectQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;

        public GetAllByProjectQueryHandler(IUserRepository userRepository, IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _userRepository = userRepository;
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllByProjectQuery request, CancellationToken cancellationToken)
        {
            var listUser = await _usuarioProjetoRepository.GetAllByProjectId(request.Query);

            var listUserViewModel = listUser
                .Select(u => new UserViewModel(u.Id, u.Nome, u.Email, u.IdCurso, u.IdCursoNavigation.Nome, u.Papel, u.IdImagemNavigation)).ToList();

            return listUserViewModel;
        }
    }
}