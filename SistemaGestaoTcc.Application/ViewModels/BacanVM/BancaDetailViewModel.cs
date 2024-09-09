using SistemaGestaoTcc.Core.Enums;

namespace SistemaGestaoTcc.Application.ViewModels.BacanVM
{
    public class BancaDetailViewModel
    {
        public BancaDetailViewModel(int id, int idProjeto, DateTime dataSeminario, ParecerBancaEnum parecer,
            string observacaoNotaProjeto, string observacaoAluno, string recomendacao)
        {
            Id = id;
            IdProjeto = idProjeto;
            DataSeminario = dataSeminario;
            Parecer = parecer;
            ObservacaoNotaProjeto = observacaoNotaProjeto;
            ObservacaoAluno = observacaoAluno;
            Recomendacao = recomendacao;
        }
        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public DateTime DataSeminario { get; set; }
        public ParecerBancaEnum Parecer { get; set; }
        public string ObservacaoNotaProjeto { get; set; }
        public string ObservacaoAluno { get; set; }
        public string Recomendacao { get; set; }
    }
}
