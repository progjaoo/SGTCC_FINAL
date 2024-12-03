using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoEntregaVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoEntrega.GetEntregaByProject
{
    public class GetEntregaByProjectQuery : IRequest<List<ProjetoEntregaViewModel>>
    {
        public int IdProjeto { get; }

        public GetEntregaByProjectQuery(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
    }
}
