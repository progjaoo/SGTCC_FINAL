using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.AvaliacaoVM
{
    public class AvaliacaoDetailViewModel
    {
        public AvaliacaoDetailViewModel(int idProjeto, AvaliacaoEnum avaliacao)
        {
            IdProjeto = idProjeto;
            Avaliacao = avaliacao;
        }

        public AvaliacaoDetailViewModel(int id, int idUsuario, int idProjeto, AvaliacaoEnum avaliacao)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdProjeto = idProjeto;
            Avaliacao = avaliacao;
        }
        public int Id {  get; set; }
        public int IdUsuario { get; set; }
        public int IdProjeto { get; set; }
        public AvaliacaoEnum Avaliacao { get; set; }

    }
}
