using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoArquivo.GetById
{
    public class GetProjetoArquivoByIdQueryHandler : IRequestHandler<GetProjetoArquivoByIdQuery, ArquivoViewModel>
    {
        private readonly IProjetoArquivoRepository _projetoArquivoRepository;
        public GetProjetoArquivoByIdQueryHandler(IProjetoArquivoRepository projetoArquivoRepository)
        {
            _projetoArquivoRepository = projetoArquivoRepository;
        }
        public async Task<ArquivoViewModel> Handle(GetProjetoArquivoByIdQuery request, CancellationToken cancellationToken)
        {
            var arquivo = await _projetoArquivoRepository.GetById(request.Id);

            if (arquivo == null) return null;

            var arquivoViewModel = new ArquivoViewModel(
                arquivo.IdArquivoNavigation.Id,
                arquivo.IdArquivoNavigation.NomeOriginal,
                arquivo.IdArquivoNavigation.Diretorio,
                arquivo.IdArquivoNavigation.Tamanho,
                arquivo.IdArquivoNavigation.Extensao,
                arquivo.IdArquivoNavigation.Id,
                arquivo.IdArquivoNavigation.CriadoEm
            );

            return arquivoViewModel;
        }
    }
}
