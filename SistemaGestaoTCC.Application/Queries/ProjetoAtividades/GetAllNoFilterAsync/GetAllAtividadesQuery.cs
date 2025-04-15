using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByProjectNoFilter
{
    public class GetByProjectIdNoFilterQuery : IRequest<List<ProjetoAtividadeDetalheViewModel>>
    {
        public int IdProjeto { get; set; }

        public GetByProjectIdNoFilterQuery(int idProjeto)
        {
            IdProjeto = idProjeto;
        }
    }
}