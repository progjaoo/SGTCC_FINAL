using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUser
{
    public class GetAllByFilterQuery : IRequest<List<ProjectFilterViewModel>>
    {
        public GetAllByFilterQuery(FiltroEnum filterEnum, string? filter, OrdenaEnum sortEnum, string? ano)
        {
           TipoFiltro = filterEnum;
           Filtro = filter;
           TipoOrdenacao = sortEnum;
           Ano = ano;
        }   
        public FiltroEnum TipoFiltro{ get; set; }
        public string? Filtro{ get; set; }
        public OrdenaEnum TipoOrdenacao { get; set;}
        public string? Ano{ get; set; }
    }
}
