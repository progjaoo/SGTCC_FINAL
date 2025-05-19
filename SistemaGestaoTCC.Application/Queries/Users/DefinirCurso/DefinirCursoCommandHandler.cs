using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.Users.DefinirCurso
{
    public class DefinirCursoCommandHandler : IRequestHandler<DefinirCursoCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DefinirCursoCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DefinirCursoCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DefinirCursoAsync(request.IdUsuario, request.IdCurso);

            return Unit.Value;
        }
    }
}
