using MediatR;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Commands.Propostas.Create
{
    public class CreatePropostaCommand : IRequest<int>
    {
        public int IdProjeto { get; set; }
        public string AtividadesPropostas { get; set; }
        public string ContribuicaoAgenda { get; set; }
        public string Sugestao { get; set; }
    }
}
