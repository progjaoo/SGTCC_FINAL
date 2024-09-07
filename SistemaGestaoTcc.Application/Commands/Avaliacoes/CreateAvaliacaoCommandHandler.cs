using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.Avaliacoes
{
    public class CreateAvaliacaoCommandHandler : IRequestHandler<CreateAvaliacaoCommand, int>
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        public CreateAvaliacaoCommandHandler(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }
        public async Task<int> Handle(CreateAvaliacaoCommand request, CancellationToken cancellationToken)
        {
            var avaliacao = new ProjetoAvaliacaoPublica(request.IdUsuario, request.IdProjeto, request.Avaliacao);

            await _avaliacaoRepository.AddASync(avaliacao);
            await _avaliacaoRepository.SaveChangesAsync();

            return avaliacao.Id;
        }
    }
}