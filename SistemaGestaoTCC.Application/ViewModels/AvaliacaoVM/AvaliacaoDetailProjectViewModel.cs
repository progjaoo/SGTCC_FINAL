using SistemaGestaoTCC.Core.Enums;
using SistemaGestaoTCC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.ViewModels.AvaliacaoVM
{
    public class AvaliacaoDetailProjectViewModel
    {
        public AvaliacaoDetailProjectViewModel(int idUsuario, AvaliacaoEnum avaliacao)
        {
            IdUsuario = idUsuario;
            Avaliacao = avaliacao;
        }
        public int IdUsuario { get; set; }
        public AvaliacaoEnum Avaliacao { get; set; }

    }
}
