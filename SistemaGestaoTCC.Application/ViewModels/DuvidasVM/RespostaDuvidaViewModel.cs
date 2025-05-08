namespace SistemaGestaoTCC.Application.ViewModels.DuvidasVM
{
    public class RespostaDuvidaViewModel
    {
        public RespostaDuvidaViewModel(int id, int idDuvida, int idUsuario, string texto, string? nomeUsuario = null, DateTime criadoEm = default)
        {
            Id = id;
            IdDuvida = idDuvida;
            IdUsuario = idUsuario;
            Texto = texto;

            NomeUsuario = nomeUsuario;
            CriadoEm = criadoEm;
        }

        public int Id { get; set; }
        public int IdDuvida { get; set; }
        public int IdUsuario { get; set; }
        public string Texto { get; set; }
        public DateTime CriadoEm { get; set; }
        public string NomeUsuario { get; set; }
    }
}
