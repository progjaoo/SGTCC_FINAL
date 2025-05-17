using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Application.ViewModels.UsersVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Users.GetAllNoFilterByProject
{
    public class GetAllNoFilterByProjectQueryHandler : IRequestHandler<GetAllNoFilterByProjectQuery, List<UsersAndFunctionViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;

        public GetAllNoFilterByProjectQueryHandler(IUserRepository userRepository, IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _userRepository = userRepository;
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }

        public async Task<List<UsersAndFunctionViewModel>> Handle(GetAllNoFilterByProjectQuery request, CancellationToken cancellationToken)
        {
            var listUserWithFunction = await _usuarioProjetoRepository.GetAllUsersAndFunctionByProjectId(request.Id);

            if (listUserWithFunction == null || !listUserWithFunction.Any())
            {
                return new List<UsersAndFunctionViewModel>();
            }

            var listUserProjectViewModel = listUserWithFunction.Select(u => new UsersAndFunctionViewModel(
                u.IdUsuarioNavigation.Id,
                u.IdUsuarioNavigation.Nome,
                u.IdUsuarioNavigation.Email,
                u.IdUsuarioNavigation.Papel,
                u.Funcao,
                u.Estado,
                u.IdUsuarioNavigation.IdImagemNavigation,
                u.IdProjetoNavigation?.Nome,
                u.Id
            )).ToList();

            return listUserProjectViewModel;
        }
    }
}