using MediatR;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.DuvidasRepostas.ResponderDuvida
{
    public class ResponderDuvidaCommandHandler : IRequestHandler<ResponderDuvidaCommand, int>
    {
        private readonly IRespostaDuvidaRepository _respostaDuvidaRepository;
        private readonly IDuvidaRepository _duvidaRepository;

        public ResponderDuvidaCommandHandler(
            IRespostaDuvidaRepository respostaDuvidaRepository,
            IDuvidaRepository duvidaRepository)
        {
            _respostaDuvidaRepository = respostaDuvidaRepository;
            _duvidaRepository = duvidaRepository;
        }

        public async Task<int> Handle(ResponderDuvidaCommand request, CancellationToken cancellationToken)
        {
            var duvida = await _duvidaRepository.GetByIdAsync(request.IdDuvida);
            if (duvida == null)
                throw new Exception("Dúvida não encontrada");

            var resposta = new RespostaDuvida(request.IdDuvida, request.IdUsuario, request.Texto);
            await _respostaDuvidaRepository.AddAsync(resposta);

            duvida.Atendida = RespotaDuvidaEnum.Sim;
            await _duvidaRepository.MarcarComoAtendidaAsync(duvida.Id);

            await _respostaDuvidaRepository.SaveChangesAsync();

            return resposta.Id;
        }
    }
}
