using MediatR;
using SistemaGestaoTCC.Application.ViewModels.RelatoriosVM;

namespace SistemaGestaoTCC.Application.Queries.Relatorios.GetById
{
    public class GetRelatorioByIdQuery : IRequest<RelatorioViewModel>
    {
        public int Id { get; set; }
        public GetRelatorioByIdQuery(int id)
        {
            Id = id;
        }
    }   

}
