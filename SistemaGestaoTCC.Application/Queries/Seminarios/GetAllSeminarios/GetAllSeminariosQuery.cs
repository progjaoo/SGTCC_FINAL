using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetAllSeminarios
{
    public class GetAllSeminariosQuery : IRequest<List<SeminarioViewModel>> {}
}
