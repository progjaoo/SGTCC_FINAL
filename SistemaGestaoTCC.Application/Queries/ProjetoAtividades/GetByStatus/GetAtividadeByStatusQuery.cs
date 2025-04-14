using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;
using SistemaGestaoTCC.Core.Enums;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetByStatus
{
    public class GetAtividadeByStatusQuery : IRequest<List<ProjetoAtividadeDetalheViewModel>>
    {
        public int IdProjeto { get; set; }
        public ProjetoAtividadeEnum Status { get; set; }
        public GetAtividadeByStatusQuery(ProjetoAtividadeEnum status, int idProjeto)
        {
            Status = status;
            IdProjeto = idProjeto;
        }
    }
}
