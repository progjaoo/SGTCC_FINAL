using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByPrioridade
{
    public class GetAtividadeByPrioridadeQuery : IRequest<List<ProjetoAtividadeDetalheViewModel>>
    {
        public PrioridadeAtividadeEnum Prioridade { get; set; }
        public int IdProjeto { get; set; }

        public GetAtividadeByPrioridadeQuery(PrioridadeAtividadeEnum prioridade, int idProjeto)
        {
            Prioridade = prioridade;
            IdProjeto = idProjeto;
        }
    }
}
