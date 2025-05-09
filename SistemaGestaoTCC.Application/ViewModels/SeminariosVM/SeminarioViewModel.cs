namespace SistemaGestaoTCC.Application.ViewModels.SeminariosVM
{
    public class SeminarioViewModel
    {
        public SeminarioViewModel(int id, int idUsuario, string requisitos, DateTime data, string? nomeCriador = null)
        {
            Id = id;
            IdUsuario = idUsuario;
            Requisitos = requisitos;
            Data = data;
            NomeCriador = nomeCriador;
        }
        public SeminarioViewModel(int id, int idUsuario, string requisitos, DateTime data, DateTime criadoEm, DateTime? editadoEm, string? nomeCriador = null)
        {
            Id = id;
            IdUsuario = idUsuario;
            Requisitos = requisitos;
            Data = data;
            CriadoEm = criadoEm;
            EditadoEm = editadoEm;

            NomeCriador = nomeCriador;
        }
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Requisitos { get; set; }
        public DateTime Data { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? EditadoEm { get; set; }
        public string? NomeCriador { get; set; }
    }
}
