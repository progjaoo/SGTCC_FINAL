using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByProject
{
    public class GetAtividadeByProjectQuery : IRequest<List<ProjetoAtividadeDetalheViewModel>>
    {
        public int IdProjeto { get; set; }

        public GetAtividadeByProjectQuery(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
    }
}
