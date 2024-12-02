using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AvaliacaoVM;
using SistemaGestaoTCC.Core.Models;

namespace SistemaGestaoTCC.Application.Queries.Avaliacoes.GetAvaliacaoByUser
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
