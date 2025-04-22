using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.ViewModels.BibliografiaVM
{
    public class BibliografiaViewModel
    {
        public BibliografiaViewModel(int idUsuario, int idProjeto, string autores, string referencia, DateTime? acessadoEm)
        {
            IdUsuario = idUsuario;
            IdProjeto = idProjeto;
            Autores = autores;
            Referencia = referencia;
            AcessadoEm = acessadoEm;
        }

        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public string Autores { get; set; }
        public string Referencia { get; set; }
        public DateTime? AcessadoEm { get; set; }
    }
}
