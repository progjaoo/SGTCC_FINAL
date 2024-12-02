using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetById
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
