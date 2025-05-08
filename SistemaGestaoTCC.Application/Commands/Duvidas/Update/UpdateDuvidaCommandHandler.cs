using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Commands.Duvidas.Update
{
    public class UpdateDuvidaCommandHandler : IRequestHandler<UpdateDuvidaCommand, Unit>
    {
        private readonly IDuvidaRepository _duvidaRepository;

        public UpdateDuvidaCommandHandler(IDuvidaRepository duvidaRepository)
        {
            _duvidaRepository = duvidaRepository;
        }

        public async Task<Unit> Handle(UpdateDuvidaCommand request, CancellationToken cancellationToken)
        {

            var duvida = await _duvidaRepository.GetByIdAsync(request.Id);
            if (duvida == null)
            {
                throw new Exception("Dúvida não encontrada");
            }
            duvida.Update(request.IdProjeto, request.IdUsuario,request.Texto, request.Visibilidade);

            await _duvidaRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
