using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetAllSeminariosByProjectId
{
    public class GetAllSeminariosByProjectIdQuery : IRequest<List<SeminarioViewModel>>
    {
        public int Id { get; set; }
    }
}
