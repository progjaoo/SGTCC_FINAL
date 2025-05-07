using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.Duvidas.Create
{
    public class CreateDuvidaCommandHandler : IRequestHandler<CreateDuvidaCommand, int>
    {
        private readonly IDuvidaRepository _duvidaRepository;

        public CreateDuvidaCommandHandler(IDuvidaRepository duvidaRepository)
        {
            _duvidaRepository = duvidaRepository;
        }

        public async Task<int> Handle(CreateDuvidaCommand request, CancellationToken cancellationToken)
        {
            var duvida = new Duvida(request.IdProjeto, request.IdUsuario, request.Texto, request.Visibilidade, request.Atendida);

            await _duvidaRepository.AddAsync(duvida);
            
            await _duvidaRepository.SaveChangesAsync();
            
            return duvida.Id;
        }
    }
}
