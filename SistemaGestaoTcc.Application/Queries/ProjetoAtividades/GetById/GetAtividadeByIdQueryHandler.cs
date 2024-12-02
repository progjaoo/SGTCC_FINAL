using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Interfaces;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetById
{
    public class GetAtividadeByIdQueryHandler : IRequestHandler<GetAtividadeByIdQuery, ProjetoAtividadeDetalheViewModel>
    {
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
        public GetAtividadeByIdQueryHandler(IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _projetoAtividadeRepository = projetoAtividadeRepository;
        }
        public async Task<ProjetoAtividadeDetalheViewModel> Handle(GetAtividadeByIdQuery request, CancellationToken cancellationToken)
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
