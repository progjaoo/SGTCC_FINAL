using MediatR;
using SistemaGestaoTCC.Application.ViewModels.RelatoriosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Relatorios.GetRelatorioByProject
{
    public class GetRelatorioByProjectQuery : IRequest<List<RelatorioViewModel>>
    {
        public GetRelatorioByProjectQuery(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
        public int IdProjeto { get; set; }
    }
}
