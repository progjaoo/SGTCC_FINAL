using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.AvaliadorBancas.Update
{
    public class UpdateAvaliadorBancaCommandHandler : IRequestHandler<UpdateAvaliadorBancaCommand, Unit>
    {
        private readonly IAvaliadorBancaRepository _avaliadorBancaRepository;

        public UpdateAvaliadorBancaCommandHandler(IAvaliadorBancaRepository avaliadorBancaRepository)
        {
            _avaliadorBancaRepository = avaliadorBancaRepository;
        }
        public async Task<Unit> Handle(UpdateAvaliadorBancaCommand request, CancellationToken cancellationToken)
        {
            var avaliadorBanca = await _avaliadorBancaRepository.GetByIdAsync(request.Id);

            if (avaliadorBanca == null)
                throw new Exception("Avaliador não encontrado");

            avaliadorBanca.IdUsuario = request.IdUsuario;
            avaliadorBanca.IdBanca = request.IdBanca;

            await _avaliadorBancaRepository.UpdateAsync(avaliadorBanca);

            return Unit.Value;
        }
    }
}
