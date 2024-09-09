namespace SistemaGestaoTcc.Application.ViewModels.AvaliadorBancaVM
{
    public class AvaliadorBancaDetalheViewModel
    {
        public AvaliadorBancaDetalheViewModel(int id, int idUsuario, int idBanca)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdBanca = idBanca;
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdBanca { get; set; }
    }
}
