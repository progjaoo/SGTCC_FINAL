using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AvaliadorBancaVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.AvaliadorBancas.GetByBanca
{
    public class GetAvaliadorBancaByBancaIdQuery : IRequest<List<AvaliadorBancaViewModel>>
    {

        public GetAvaliadorBancaByBancaIdQuery(int idBanca)
        {
            IdBanca = idBanca;
        }
        public int IdBanca { get; set; }
    }
}
