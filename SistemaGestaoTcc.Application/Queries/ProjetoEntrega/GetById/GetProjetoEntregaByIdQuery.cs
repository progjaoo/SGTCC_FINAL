using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoEntregaVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoEntrega.GetById
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