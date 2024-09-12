using MediatR;
using SistemaGestaoTcc.Core.Interfaces;

namespace SistemaGestaoTcc.Application.Commands.CamposDocumento.Delete
{
    public class DeleteCampoCommandHandler : IRequestHandler<DeleteCampoCommand, bool>
    {
        private readonly ICampoDocumentoRepository _campoDocumentoRepository;
        public DeleteCampoCommandHandler(ICampoDocumentoRepository campoDocumentoRepository)
        {
            _campoDocumentoRepository = campoDocumentoRepository;
        }
        public async Task<bool> Handle(DeleteCampoCommand request, CancellationToken cancellationToken)
        {
            var campo = await _campoDocumentoRepository.GetByIdAsync(request.Id);

            if (campo == null) return false;

            await _campoDocumentoRepository.DeleteAsync(campo.Id);

            return true;
        }
    }
}
