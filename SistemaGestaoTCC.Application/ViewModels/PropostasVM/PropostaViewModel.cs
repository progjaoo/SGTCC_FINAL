using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.ViewModels.PropostasVM
{
    public class PropostaViewModel
    {
        public PropostaViewModel(int idProjeto, string atividadesPropostas, string contribuicaoAgenda, string sugestao, ParecerPropostaEnum parecer)
        {
            IdProjeto = idProjeto;
            AtividadesPropostas = atividadesPropostas;
            ContribuicaoAgenda = contribuicaoAgenda;
            Sugestao = sugestao;
            Parecer = parecer;
        }
        public PropostaViewModel(int id, int idProjeto, string atividadesPropostas, string contribuicaoAgenda, string sugestao, ParecerPropostaEnum parecer, DateTime criadoEm)
        {
            Id = id;
            IdProjeto = idProjeto;
            AtividadesPropostas = atividadesPropostas;
            ContribuicaoAgenda = contribuicaoAgenda;
            Sugestao = sugestao;
            Parecer = parecer;
            CriadoEm = criadoEm;
        }

        public int Id { get; set; }
        public int IdProjeto { get; set; }
        public string AtividadesPropostas { get; set; }
        public string ContribuicaoAgenda { get; set; }
        public string Sugestao { get; set; }
        public ParecerPropostaEnum Parecer { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
