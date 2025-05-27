using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;
using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetAllByCourse
{
    public class GetAllDuvidasByCourseQuery : IRequest<List<DuvidasViewModel>>
    {
        public int Id { get; set; }
    }
}
