using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.Seminarios.CreateSeminariosProjeto
{
    public class CreateSeminarioProjetoCommandHandler : IRequestHandler<CreateSeminarioProjetoCommand, int>
    {
        private readonly ISeminarioRepository _seminarioRepository;
        public CreateSeminarioProjetoCommandHandler(ISeminarioRepository seminarioRepository)
        {
            _seminarioRepository = seminarioRepository;
        }
        public async Task<int> Handle(CreateSeminarioProjetoCommand request, CancellationToken cancellationToken)
        {
            var seminario = new SeminarioProjeto(request.IdSeminario, request.IdProjeto);

            await _seminarioRepository.AddSeminarioProjeto(seminario);
            await _seminarioRepository.SaveChangesAsync();

            return seminario.Id;
        }
    }
}
