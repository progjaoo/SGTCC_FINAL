using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetDuvidaByUser
{
    public class GetDuvidaByUserQuery : IRequest<List<DuvidasViewModel>>
    {
        public GetDuvidaByUserQuery(int idUsuario)
        {
            IdUsuario = idUsuario;
        }
        public int IdUsuario { get; set; }
    }
}
