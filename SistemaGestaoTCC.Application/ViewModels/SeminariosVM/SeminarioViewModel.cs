namespace SistemaGestaoTCC.Application.ViewModels.SeminariosVM
{
    public class SeminarioViewModel
    {
        public SeminarioViewModel(int idUsuario, string requisitos, DateTime data)
        {
            IdUsuario = idUsuario;
            Requisitos = requisitos;
            Data = data;
        }
        public SeminarioViewModel(int idUsuario, string requisitos, DateTime data, DateTime criadoEm, DateTime? editadoEm)
        {
            
            IdUsuario = idUsuario;
            Requisitos = requisitos;
            Data = data;
            CriadoEm = criadoEm;
            EditadoEm = editadoEm;
        }
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Requisitos { get; set; }
        public DateTime Data { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? EditadoEm { get; set; }
    }
}
