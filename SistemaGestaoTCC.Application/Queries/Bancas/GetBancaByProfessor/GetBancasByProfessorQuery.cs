using MediatR;
using SistemaGestaoTCC.Application.ViewModels.BacanVM;

namespace SistemaGestaoTCC.Application.Queries.Bancas.GetBancaByProfessor
{
    public class GetBancasByProfessorQuery : IRequest<List<BancaDetailViewModel>>
    {
        public GetBancasByProfessorQuery(int idUsuario)
        {
            IdUsuario = idUsuario;
        }
        public int IdUsuario { get; set; }
    }

}
