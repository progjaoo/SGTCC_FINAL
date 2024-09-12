namespace SistemaGestaoTcc.Application.ViewModels.CategoriaVM
{
    public class CategoriaViewModel
    {
        public CategoriaViewModel(int id, string valor)
        {
            Id = id;
            Valor = valor;
        }

        public int Id { get; set; }
        public string Valor { get; set; }
    }
}
