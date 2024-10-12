using MediatR;
using SistemaGestaoTcc.Application.ViewModels.UsersVM;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Queries.UsuariosProjeto
{
    public class GetUserProjectByIdQueryHandler : IRequestHandler<GetUserProjectByIdQuery, UserProjectViewModel>
    {
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;
        public GetUserProjectByIdQueryHandler(IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }
        public async Task<UserProjectViewModel> Handle(GetUserProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var userProject = await _usuarioProjetoRepository.GetById(request.Id);

            if (userProject == null)
                return null;

            var userProjectViewModel = new UserProjectViewModel(
                userProject.IdUsuario, 
                userProject.IdProjeto,
                userProject.Funcao);

            return userProjectViewModel;
        }
    }
}
