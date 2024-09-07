using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AvaliacaoVM;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Queries.Avaliacoes.GetById
{
    public class GetAvaliacaoByIdQuery : IRequest<AvaliacaoDetailViewModel>
    {
        public int Id { get; set; }

        public GetAvaliacaoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
