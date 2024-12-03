using MediatR;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Commands.CamposDocumento.Create
{
    public class CreateCampoCommandHandler : IRequestHandler<CreateCampoCommand, int>
    {
        private readonly ICampoDocumentoRepository _campoDocumentoRepository;
        public CreateCampoCommandHandler(ICampoDocumentoRepository campoDocumentoRepository)
        {
            _campoDocumentoRepository = campoDocumentoRepository;
        }
        public async Task<int> Handle(CreateCampoCommand request, CancellationToken cancellationToken)
        {
            var campo = new CampoDocumentoAvaliacaoAluno(request.Campo, request.IdCategoria);

            await _campoDocumentoRepository.AddAsync(campo);

            return campo.Id;
        }
    }
}
