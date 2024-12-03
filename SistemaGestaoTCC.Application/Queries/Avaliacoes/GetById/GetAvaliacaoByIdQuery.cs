using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AvaliacaoVM;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Avaliacoes.GetById
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
