namespace SistemaGestaoTCC.Application.ViewModels.BacanVM
{
    public class BancaProjetoDetalhesDetalhesViewModel
    {
        public string NomeProjeto { get; set; }
        public string Descricao { get; set; }
        public string ObservacaoNotaProjeto { get; set; }
        public string ObservacaoAluno { get; set; }
        public string Recomendacao { get; set; }
        public List<string> Participantes { get; set; }
        public List<NotaFinalAlunoViewModel> NotasFinais { get; set; }
        public List<string> Avaliadores { get; set; }  

    }
}
