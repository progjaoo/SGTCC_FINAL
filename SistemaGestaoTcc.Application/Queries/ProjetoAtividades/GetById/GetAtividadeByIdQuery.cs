using MediatR;
using SistemaGestaoTcc.Application.ViewModels.ProjetoAtividadeVM;

namespace SistemaGestaoTcc.Application.Queries.ProjetoAtividades.GetById
{
    public class GetAtividadeByIdQuery : IRequest<ProjetoAtividadeDetalheViewModel>
    {
        public int Id { get; set; }

        public GetAtividadeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
