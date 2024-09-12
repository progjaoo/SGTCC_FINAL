using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.CamposDocumento.Update
{
    public class UpdateCampoCommandHandler : IRequestHandler<UpdateCampoCommand, Unit>
    {
        private readonly ICampoDocumentoRepository _campoDocumentoRepository;
        public UpdateCampoCommandHandler(ICampoDocumentoRepository campoDocumentoRepository)
        {
            _campoDocumentoRepository = campoDocumentoRepository;
        }
        public async Task<Unit> Handle(UpdateCampoCommand request, CancellationToken cancellationToken)
        {
            var campo = await _campoDocumentoRepository.GetByIdAsync(request.Id);

            campo.UpdateCampo(request.Campo, request.IdCategoria);

            await _campoDocumentoRepository.SaveChangesAsync();
            
            return Unit.Value;
        }
    }
}
