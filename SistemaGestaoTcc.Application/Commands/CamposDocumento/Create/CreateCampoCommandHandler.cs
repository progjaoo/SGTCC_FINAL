using MediatR;
using SistemaGestaoTcc.Core.Interfaces;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Commands.CamposDocumento.Create
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
