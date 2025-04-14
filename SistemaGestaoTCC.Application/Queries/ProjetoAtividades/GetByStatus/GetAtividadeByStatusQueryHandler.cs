using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByStatus
{
    public class GetAtividadeByStatusQueryHandler : IRequestHandler<GetAtividadeByStatusQuery, List<ProjetoAtividadeDetalheViewModel>>
    {
        private readonly IProjetoAtividadeRepository _projetoAtividadeRepository;
        public GetAtividadeByStatusQueryHandler(IProjetoAtividadeRepository projetoAtividadeRepository)
        {
            _projetoAtividadeRepository = projetoAtividadeRepository;
        }
        public async Task<List<ProjetoAtividadeDetalheViewModel>> Handle(GetAtividadeByStatusQuery request, CancellationToken cancellationToken)
        {
            var atividades = await _projetoAtividadeRepository.GetByStatusAsync(request.Status, request.IdProjeto);

            var atividadeViewModels = atividades.Select(a => new ProjetoAtividadeDetalheViewModel(a.Id,a.IdProjeto, a.Nome, a.Descricao, a.Estado, a.CriadoEm)).ToList();

            return atividadeViewModels;
        }
    }
}
