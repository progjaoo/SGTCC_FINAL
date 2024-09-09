using SistemaGestaoTcc.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTcc.Application.ViewModels.BacanVM
{
    public class BancaViewModel
    {
        public BancaViewModel(int id, int idProjeto, DateTime dataSeminario, ParecerBancaEnum parecer)
        {
            Id = id;
            IdProjeto = idProjeto;
            DataSeminario = dataSeminario;
            Parecer = parecer;
        }

        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public DateTime DataSeminario { get; set; }
        public ParecerBancaEnum Parecer { get; set; }
    }
}
