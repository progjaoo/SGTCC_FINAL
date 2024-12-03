using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.UsuariosProjeto.RemoverUsuarioProjeto
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Unit>
    {
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;

        public RemoveUserCommandHandler(IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }

        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var userProject = await _usuarioProjetoRepository.GetByUserAndProjectAsync(request.IdUsuario, request.IdProjeto);

            if (userProject == null)
            {
                throw new Exception($"O usuário com ID {request.IdUsuario} não está vinculado ao projeto {request.IdProjeto}.");
            }

            await _usuarioProjetoRepository.DeleteUserProj(userProject);
            await _usuarioProjetoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}