using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetSeminariosById
{
    public class GetSeminarioByIdQuery : IRequest<SeminarioViewModel>
    {
        public int Id { get; set; }
        public GetSeminarioByIdQuery(int id)
        {
            Id = id;
        }
    }
}
