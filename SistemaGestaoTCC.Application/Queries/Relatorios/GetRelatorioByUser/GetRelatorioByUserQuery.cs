using MediatR;
using SistemaGestaoTCC.Application.ViewModels.RelatoriosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Relatorios.GetRelatorioByUser
{
    public class GetRelatorioByUserQuery : IRequest<List<RelatorioViewModel>>
    {
        public GetRelatorioByUserQuery(int idUsuario)
        {
            IdUsuario = idUsuario;
        }
        public int IdUsuario { get; set; }
    }
}
