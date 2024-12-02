using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.AvaliadorBancas.Create
{
    public class CreateAvaliadorBancaCommandHandler : IRequestHandler<CreateAvaliadorBancaCommand, int>
    {
        private readonly IAvaliadorBancaRepository _avaliadorBancaRepository;

        public CreateAvaliadorBancaCommandHandler(IAvaliadorBancaRepository avaliadorBancaRepository)
        {
            _avaliadorBancaRepository = avaliadorBancaRepository;
        }

        public async Task<int> Handle(CreateAvaliadorBancaCommand request, CancellationToken cancellationToken)
        {
            var avaliadorBanca = new AvaliadorBanca(request.IdUsuario,request.IdBanca);

            await _avaliadorBancaRepository.AddAsync(avaliadorBanca);
            await _avaliadorBancaRepository.SaveChangesAsync();
            return avaliadorBanca.Id; 
        }
    }

}
