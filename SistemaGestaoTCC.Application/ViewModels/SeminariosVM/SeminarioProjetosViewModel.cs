namespace SistemaGestaoTCC.Application.ViewModels.SeminariosVM
{
    public class SeminarioProjetosViewModel
    {
        public SeminarioProjetosViewModel(int idSeminario, int idProjeto)
        {
            IdSeminario = idSeminario;
            IdProjeto = idProjeto;
        }

        public SeminarioProjetosViewModel(int id, int idSeminario, int idProjeto, DateTime criadoEm, DateTime? editadoEm)
        {
            Id = id;
            IdSeminario = idSeminario;
            IdProjeto = idProjeto;
            CriadoEm = criadoEm;
            EditadoEm = editadoEm;
        }

        public SeminarioProjetosViewModel(int id, int idSeminario, int idProjeto, DateTime criadoEm, DateTime? editadoEm,
            string nomeProjeto, string descricaoProjeto, DateTime dataInicio, List<UserViewModel> usuarios)
        {
            Id = id;
            IdSeminario = idSeminario;
            IdProjeto = idProjeto;
            CriadoEm = criadoEm;
            EditadoEm = editadoEm;
            NomeProjeto = nomeProjeto;
            DescricaoProjeto = descricaoProjeto;
            DataInicio = dataInicio;
            Usuarios = usuarios;
        }

        public int Id { get; set; }
        public int IdSeminario { get; set; }
        public int IdProjeto { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? EditadoEm { get; set; }

        public string NomeProjeto { get; set; }
        public string DescricaoProjeto { get; set; }
        public DateTime DataInicio { get; set; }
        public List<UserViewModel> Usuarios { get; set; }
    }
}