using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Anotacoes.GetByProject
{
    public class GetAnotacaoByProjectQuery : IRequest<List<AnotacaoViewModel>>
    {
        public GetAnotacaoByProjectQuery(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
        public int IdProjeto { get; set; }
    }
}
