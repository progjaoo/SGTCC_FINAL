using MediatR;
using SistemaGestaoTCC.Application.ViewModels.UsersVM;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.UsuariosProjeto.GetInvitesByUserId
{
    public class GetInvitesByUserIdCommandHandler : IRequestHandler<GetInvitesByUserIdCommand, List<UsersAndFunctionViewModel>>
    {
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;

        public GetInvitesByUserIdCommandHandler(IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }

        public async Task<List<UsersAndFunctionViewModel>> Handle(GetInvitesByUserIdCommand request, CancellationToken cancellationToken)
        {
            var userInvites = await _usuarioProjetoRepository.GetAllInvitesByUserId(request.IdUsuario);

            var listUserProjectViewModel = userInvites.Select(u => new UsersAndFunctionViewModel(
                u.IdUsuarioNavigation.Id,
                u.IdUsuarioNavigation.Nome,
                u.IdUsuarioNavigation.Email,
                u.IdUsuarioNavigation.Papel,
                u.Funcao,
                u.Estado,
                u.IdUsuarioNavigation.IdImagemNavigation
            )).ToList();

            return listUserProjectViewModel;
        }
    }
}