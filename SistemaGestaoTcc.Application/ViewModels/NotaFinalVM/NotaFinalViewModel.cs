using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.ViewModels.NotaFinalVM
{
    public class NotaFinalViewModel
    {
        public NotaFinalViewModel(int idAluno, int nota, string nome)
        {
            IdAluno = idAluno;
            Nota = nota;
            Nome = nome;
        }

        public int IdAluno { get; set; }
        public int Nota { get; set; }
        public string Nome { get; set; }
    }
}
