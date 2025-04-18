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
        public AvaliacaoDetailProjectViewModel(int id, int idUsuario, AvaliacaoEnum avaliacao)
        {
            Id = id;
            IdUsuario = idUsuario;
            Avaliacao = avaliacao;
        }
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public AvaliacaoEnum Avaliacao { get; set; }

    }
}
