using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.Propostas.ParecerProposta
{
    public class UpdateParecerPropostaCommandHandler : IRequestHandler<UpdateParecerPropostaCommand, bool>
    {
        private readonly IPropostaRepository _propostaRepository;

        public UpdateParecerPropostaCommandHandler(IPropostaRepository propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }

        public async Task<bool> Handle(UpdateParecerPropostaCommand request, CancellationToken cancellationToken)
        {
            var proposta = await _propostaRepository.AtualizarParecerAsync(request.Id, request.NovoParecer);



            if (proposta == null) return false; 
            
            return true;
        }
    }
}
