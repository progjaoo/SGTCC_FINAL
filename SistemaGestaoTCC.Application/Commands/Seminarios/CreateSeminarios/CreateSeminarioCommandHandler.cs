using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.CreateSeminarios
{
    public class CreateSeminarioCommandHandler : IRequestHandler<CreateSeminarioCommand, int>
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public CreateSeminarioCommandHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }
        public async Task<int> Handle(CreateSeminarioCommand request, CancellationToken cancellationToken)
        {
            var seminario = new Seminario(request.IdUsuario, request.Requisitos, request.Data);

            await _seminarioRepository.AddASync(seminario);

            return seminario.Id;
        }
    }
}
