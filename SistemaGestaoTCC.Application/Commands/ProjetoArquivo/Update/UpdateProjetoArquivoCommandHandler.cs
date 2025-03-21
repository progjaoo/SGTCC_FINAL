using MediatR;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Commands.ProjetoArquivo.Update
{
    public class UpdateProjetoArquivoCommandHandler : IRequestHandler<UpdateProjetoArquivoCommand, Unit>
    {
        private readonly IProjetoArquivoRepository _projetoArquivoRepository;

        public UpdateProjetoArquivoCommandHandler(IProjetoArquivoRepository projetoArquivoRepository)
        {
            _projetoArquivoRepository = projetoArquivoRepository;
        }

        public async Task<Unit> Handle(UpdateProjetoArquivoCommand request, CancellationToken cancellationToken)
        {

            return Unit.Value;
        }
    }
}
