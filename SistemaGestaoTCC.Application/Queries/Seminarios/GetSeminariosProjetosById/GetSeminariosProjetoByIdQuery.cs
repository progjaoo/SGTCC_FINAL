using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetSeminariosProjetosById
{
    public class GetSeminariosProjetoByIdQuery : IRequest<SeminarioProjetosViewModel>
    {
        public int Id { get; set; }
        public GetSeminariosProjetoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
