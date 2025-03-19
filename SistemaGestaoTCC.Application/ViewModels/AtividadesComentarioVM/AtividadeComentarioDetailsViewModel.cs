using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestaoTCC.Application.ViewModels.AtividadesComentarioVM
{
    public class AtividadeComentarioDetailsViewModel
    {
        public AtividadeComentarioDetailsViewModel(int idUsuario, int idAtividade, string comentario, string nomeUsuario)
        {
            IdUsuario = idUsuario;
            IdAtividade = idAtividade;
            Comentario = comentario;
            NomeUsuario = nomeUsuario;
        }

        public AtividadeComentarioDetailsViewModel(int idUsuario, int idAtividade, string comentario, string nomeUsuario, int idComentario)
        {
            IdUsuario = idUsuario;
            IdAtividade = idAtividade;
            Comentario = comentario;
            NomeUsuario = nomeUsuario;
            Id = idComentario;
        }
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdAtividade { get; set; }
        public string Comentario { get; set; }
        public string NomeUsuario { get; set; }
    }
}
