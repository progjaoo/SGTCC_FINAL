using MediatR;
using SistemaGestaoTCC.Application.ViewModels.UsersVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.UsuariosProjeto
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
