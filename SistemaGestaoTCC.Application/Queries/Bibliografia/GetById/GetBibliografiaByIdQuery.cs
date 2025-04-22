using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;
using SistemaGestaoTCC.Application.ViewModels.BibliografiaVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Bibliografia.GetById
{
    public class GetBibliografiaByIdQuery : IRequest<BibliografiaDetalheViewModel>
    {
        public GetBibliografiaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
