using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AvaliacaoVM;
using SistemaGestaoTcc.Core.Models;

namespace SistemaGestaoTcc.Application.Queries.Avaliacoes.GetAvaliacaoByUser
{
    public class GetAvaliacoesByUsuarioQuery : IRequest<List<AvaliacaoDetailViewModel>>
    {
        public int Id { get; set; }

        public GetAvaliacoesByUsuarioQuery(int idUsuario)
        {
            Id = idUsuario;
        }
    }
}
