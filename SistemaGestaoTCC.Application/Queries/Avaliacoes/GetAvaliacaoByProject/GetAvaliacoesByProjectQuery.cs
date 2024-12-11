using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AvaliacaoVM;

namespace SistemaGestaoTCC.Application.Queries.Avaliacoes.GetAvaliacaoByProject
{
    public class GetAvaliacoesByProjectQuery : IRequest<List<AvaliacaoDetailProjectViewModel>>
    {
        public int Id { get; set; }

        public GetAvaliacoesByProjectQuery(int idProjeto)
        {
            Id = idProjeto;
        }
    }
}