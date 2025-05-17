using SistemaGestaoTCC.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.ViewModels.DuvidasVM
{
    public class DuvidasViewModel
    {
        public DuvidasViewModel(int id, int idProjeto, int idUsuario, string texto, VisibilidadeDuvidaEnum visibilidade, RespotaDuvidaEnum atendida, DateTime criadoEm, string? nomeUsuario = null)
        {
            Id = id;
            IdProjeto = idProjeto;
            IdUsuario = idUsuario;
            Texto = texto;
            Visibilidade = visibilidade;
            Atendida = atendida;
            CriadoEm = criadoEm;

            NomeUsuario = nomeUsuario;

        }

        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public int IdUsuario { get; set; }
        public string Texto { get; set; }
        public VisibilidadeDuvidaEnum Visibilidade { get; set; }
        public RespotaDuvidaEnum Atendida { get; set; }
        public DateTime CriadoEm { get; set; }
        public string NomeUsuario { get; set; }
    }
}
