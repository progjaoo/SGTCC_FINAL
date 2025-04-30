using MediatR;

namespace SistemaGestaoTCC.Application.Commands.Propostas.Update
{
    public class UpdatePropostaCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string AtividadesPropostas { get; set; }
        public string ContribuicaoAgenda { get; set; }
        public string Sugestao { get; set; }
    }
}
