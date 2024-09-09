using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.Commands.AvaliadorBancas.Delete
{
    public class DeleteAvaliadorBancaCommandHandler : IRequestHandler<DeleteAvaliadorBancaCommand, Unit>
    {
        private readonly IAvaliadorBancaRepository _avaliadorBancaRepository;

        public DeleteAvaliadorBancaCommandHandler(IAvaliadorBancaRepository avaliadorBancaRepository)
        {
            _avaliadorBancaRepository = avaliadorBancaRepository;
        }

        public async Task<Unit> Handle(DeleteAvaliadorBancaCommand request, CancellationToken cancellationToken)
        {
            var avaliadorBanca = await _avaliadorBancaRepository.GetByIdAsync(request.Id);

            if (avaliadorBanca == null)
                throw new Exception("Avaliador não encontrado");

            await _avaliadorBancaRepository.DeleteAsync(avaliadorBanca.Id);
            await _avaliadorBancaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
