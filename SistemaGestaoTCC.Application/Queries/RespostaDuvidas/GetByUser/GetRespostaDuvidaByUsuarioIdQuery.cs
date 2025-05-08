using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;

namespace SistemaGestaoTCC.Application.Queries.RespostaDuvidas.GetByUser
{
    public class GetRespostaDuvidaByUsuarioIdQuery : IRequest<List<RespostaDuvidaViewModel>>
    {
        public GetRespostaDuvidaByUsuarioIdQuery(int idUsuario)
        {
            IdUsuario = idUsuario;
        }
        public int IdUsuario { get; set; }
    }
}
