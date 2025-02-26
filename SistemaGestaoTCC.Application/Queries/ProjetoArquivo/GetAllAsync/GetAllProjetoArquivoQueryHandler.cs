using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ArquivoVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoArquivo.GetAllAsync
{
    public class GetAllProjetoArquivoQueryHandler : IRequestHandler<GetAllProjetoArquivoQuery, List<ArquivoViewModel>>
    {
        private readonly IProjetoArquivoRepository _projetoArquivoRepository;
        public GetAllProjetoArquivoQueryHandler(IProjetoArquivoRepository projetoArquivoRepository)
        {
            _projetoArquivoRepository = projetoArquivoRepository;
        }
        public async Task<List<ArquivoViewModel>> Handle(GetAllProjetoArquivoQuery request, CancellationToken cancellationToken)
        {
            var atividade = await _projetoArquivoRepository.GetAllAsync();

            var atividadeViewModel = atividade.Select(a => new ProjetoAtividadeViewModel(a.IdProjeto, a.Nome)).ToList();

            return atividadeViewModel;  
        }
    }
}
