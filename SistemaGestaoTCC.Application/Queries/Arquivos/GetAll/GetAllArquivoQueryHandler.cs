using MediatR;
using Microsoft.EntityFrameworkCore;
using SistemaGestaoTCC.Core.Interfaces;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Arquivos.GetAll
{
    public class GetAllArquivoQueryHandler : IRequestHandler<GetAllArquivoQuery, List<Arquivo>>
    {
        private readonly IArquivoRepository _arquivoRepository;

        public GetAllArquivoQueryHandler(IArquivoRepository arquivoRepository)
        {
            _arquivoRepository = arquivoRepository;
        }

        public async Task<List<Arquivo>> Handle(GetAllArquivoQuery request, CancellationToken cancellationToken)
        {
            var arquivos = await _arquivoRepository.GetAllAsync();
                // .ToListAsync(cancellationToken);

            return arquivos;
        }
    }
}
