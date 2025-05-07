using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;

namespace SistemaGestaoTCC.Application.Queries.Duvidas.GetDuvidaByProject
{
    public class GetDuvidaByProjectQuery : IRequest<List<DuvidasViewModel>>
    {
        public GetDuvidaByProjectQuery(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
        public int IdProjeto { get; set; }
    }
}
