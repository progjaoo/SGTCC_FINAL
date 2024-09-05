namespace SistemaGestaoTcc.Application.ViewModels.ProjetoAtividadeVM
{
    public class ProjetoAtividadeViewModel
    {
        public ProjetoAtividadeViewModel(int idProjeto, string nome)
        {
            IdProjeto = idProjeto;
            Nome = nome;
        }

        public int IdProjeto { get; set; }
        public string Nome { get; set; }
    }
}
