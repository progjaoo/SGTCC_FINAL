using MediatR;
using SistemaGestaoTcc.Application.ViewModels.ProjetoEntregaVM;

namespace SistemaGestaoTcc.Application.Queries.ProjetoEntrega.GetById
{
    public class GetProjetoEntregaByIdQuery : IRequest<ProjetoEntregaViewModel>
    {
        public GetProjetoEntregaByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}