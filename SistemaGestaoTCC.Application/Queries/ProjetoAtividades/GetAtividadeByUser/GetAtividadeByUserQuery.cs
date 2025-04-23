using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetAtividadeByUser
{
    public class GetAtividadeByUserQuery : IRequest<List<ProjetoAtividadeDetalheViewModel>>
    {
        public int IdUsuario { get; set; }
        public GetAtividadeByUserQuery(int idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}
