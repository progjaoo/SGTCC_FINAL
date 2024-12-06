using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SistemaGestaoTCC.Application.ViewModels;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Queries.Projects.GetProjectsByUser
{
    public class GetAllByFilterQuery : IRequest<List<ProjectFilterViewModel>>
    {
        public GetAllByFilterQuery(FiltroEnum filterEnum, string filter, OrdenaEnum sortEnum, string? ano)
        {
           FilterEnum = filterEnum;
           Filter = filter;
           SortEnum = sortEnum;
           Ano = ano;
        }   
        public FiltroEnum FilterEnum{ get; set; }
        public string Filter{ get; set; }
        public OrdenaEnum SortEnum { get; set;}
        public string? Ano{ get; set; }
    }
}
