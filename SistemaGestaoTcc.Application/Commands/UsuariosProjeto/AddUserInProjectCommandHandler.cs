using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.UsuariosProjeto
{
    public class AddUserInProjectCommandHandler : IRequestHandler<AddUserInProjectCommand, int>
    {
        private readonly IUsuarioProjetoRepository _usuarioProjetoRepository;
        public AddUserInProjectCommandHandler(IUsuarioProjetoRepository usuarioProjetoRepository)
        {
            _usuarioProjetoRepository = usuarioProjetoRepository;
        }
        public async Task<int> Handle(AddUserInProjectCommand request, CancellationToken cancellationToken)
        {
            var userProject = new UsuarioProjeto(request.IdUsuario, request.IdProjeto, request.Funcao);

            await _usuarioProjetoRepository.AddASync(userProject);
            await _usuarioProjetoRepository.SaveChangesAsync();

            return userProject.Id;
        }
    }
}