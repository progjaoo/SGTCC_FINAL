using MediatR;
using SistemaGestaoTCC.Application.ViewModels.PropostasVM;

namespace SistemaGestaoTCC.Application.Queries.Propostas.GetAllByCourse
{
    public class GetAllByCoursePropostasQuery : IRequest<List<PropostaViewModel>>
    {
        public int Id { get; set; }
    }
}
