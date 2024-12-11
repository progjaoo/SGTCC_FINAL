using SistemaGestaoTCC.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.ViewModels.AvaliacaoVM
{
    public class AvaliacaoDetailUsuarioViewModel
    {
        public AvaliacaoDetailUsuarioViewModel(int idProjeto, AvaliacaoEnum avaliacao)
        {
            IdProjeto = idProjeto;
            Avaliacao = avaliacao;
        }

        public int IdProjeto { get; set; }
        public AvaliacaoEnum Avaliacao { get; set; }
    }
}
