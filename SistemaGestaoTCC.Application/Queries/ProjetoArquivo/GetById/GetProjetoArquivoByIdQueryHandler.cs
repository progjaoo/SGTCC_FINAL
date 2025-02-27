using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetById
{
    public class GetProjetoArquivoByIdQueryHandler : IRequestHandler<GetProjetoArquivoByIdQuery, ProjetoAtividadeDetalheViewModel>
    {
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
        public GetProjetoArquivoByIdQueryHandler(IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _projetoAtividadeRepository = projetoAtividadeRepository;
        }
        public async Task<ProjetoAtividadeDetalheViewModel> Handle(GetProjetoArquivoByIdQuery request, CancellationToken cancellationToken)
        {
            var atividade = await _projetoAtividadeRepository.GetById(request.Id);

            if (atividade == null) return null;

            var atividadeDetalheViewModel = new ProjetoAtividadeDetalheViewModel(
                atividade.Id,
                atividade.IdProjeto,
                atividade.Nome,
                atividade.Descricao,
                atividade.Estado);

            return atividadeDetalheViewModel;
        }
    }
}
