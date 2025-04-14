using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByProject
{
    public class GetAtividadeByProjectQueryHandler : IRequestHandler<GetAtividadeByProjectQuery, List<ProjetoAtividadeDetalheViewModel>>
    {
        private readonly IProjetoAtividadeRepository _atividadeRepositorio;
        public GetAtividadeByProjectQueryHandler(IProjetoAtividadeRepository atividadeRepositorio)
        {
            _atividadeRepositorio = atividadeRepositorio;
        }

        public async Task<List<ProjetoAtividadeDetalheViewModel>> Handle(GetAtividadeByProjectQuery request, CancellationToken cancellationToken)
        {
            var atividades = await _atividadeRepositorio.GetAtividadeByProjectIdAsync(request.IdProjeto);

            var atividadeViewModel = atividades.Select(a => new ProjetoAtividadeDetalheViewModel(a.Id, a.IdProjeto, a.Nome, a.Descricao, a.Estado, a.CriadoEm)).ToList();

            return atividadeViewModel;
        }
    }
}
