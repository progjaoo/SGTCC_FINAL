namespace SistemaGestaoTCC.Application.ViewModels.AnotacaoVM
{
    public class AnotacaoViewModel
    {
        public AnotacaoViewModel(int idUsuario, int idProjeto, string titulo, string descricao, DateTime criadoEm)
        {
            IdUsuario = idUsuario;
            IdProjeto = idProjeto;
            Titulo = titulo;
            Descricao = descricao;
            CriadoEm = criadoEm;
        }

        public AnotacaoViewModel(int id, int idUsuario, int idProjeto, string titulo, string descricao, DateTime criadoEm)
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
    }
}
