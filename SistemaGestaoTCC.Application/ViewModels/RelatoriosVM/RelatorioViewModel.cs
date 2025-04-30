namespace SistemaGestaoTCC.Application.ViewModels.RelatoriosVM
{
    public class RelatorioViewModel
    {
        public RelatorioViewModel(int idProfessor, int idProjeto, string? titulo, string descricao, int duracaoEncontro, DateTime dataRealizacao, DateTime criadoEm)
        {
            IdProfessor = idProfessor;
            IdProjeto = idProjeto;
            Titulo = titulo;
            Descricao = descricao;
            DuracaoEncontro = duracaoEncontro;
            DataRealizacao = dataRealizacao;
            CriadoEm = criadoEm;
        }
        public int IdProfessor { get; set; }
        public int IdProjeto { get; set; }
        public string? Titulo { get; set; }
        public string Descricao { get; set; }
        public int DuracaoEncontro { get; set; }
        public DateTime DataRealizacao { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}