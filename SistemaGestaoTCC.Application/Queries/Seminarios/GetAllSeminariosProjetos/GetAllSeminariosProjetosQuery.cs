using MediatR;
using SistemaGestaoTCC.Application.ViewModels.SeminariosVM;

namespace SistemaGestaoTCC.Application.Queries.Seminarios.GetAllSeminariosProjetos
{
    public class GetAllSeminariosProjetosQuery : IRequest<List<SeminarioProjetosViewModel>> { }
}
