using MediatR;
using SistemaGestaoTcc.Application.ViewModels.ProjetoEntregaVM;

namespace SistemaGestaoTcc.Application.Queries.ProjetoEntrega.GetEntregaByProject
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
