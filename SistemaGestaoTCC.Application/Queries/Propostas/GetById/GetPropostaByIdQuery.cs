using MediatR;
using SistemaGestaoTCC.Application.ViewModels.PropostasVM;

namespace SistemaGestaoTCC.Application.Queries.Propostas.GetById
{
    public class GetPropostaByIdQuery : IRequest<PropostaViewModel>
    {
        public GetPropostaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
