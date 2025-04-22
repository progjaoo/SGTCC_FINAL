using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.ViewModels.AnotacaoVM
{
    public class AnotacaoDetalheViewModel
    {
        public AnotacaoDetalheViewModel(int id, int idUsuario, int idProjeto, string titulo, string descricao, DateTime criadoEm, DateTime? editadoEm)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdProjeto = idProjeto;
            Titulo = titulo;
            Descricao = descricao;
            CriadoEm = criadoEm;
        }
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? EditadoEm { get; set; }
    }
}
