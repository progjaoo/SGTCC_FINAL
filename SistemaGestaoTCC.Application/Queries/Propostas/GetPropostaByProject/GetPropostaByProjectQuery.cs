using MediatR;
using SistemaGestaoTCC.Application.ViewModels.PropostasVM;
using SistemaGestaoTCC.Application.ViewModels.RelatoriosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Propostas.GetPropostaByProject
{
    public class GetPropostaByProjectQuery : IRequest<List<PropostaViewModel>>
    {
        public GetPropostaByProjectQuery(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
        public int IdProjeto { get; set; }
    }
}
