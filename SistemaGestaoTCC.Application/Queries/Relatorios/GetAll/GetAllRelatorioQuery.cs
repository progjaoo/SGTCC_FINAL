using MediatR;
using SistemaGestaoTCC.Application.ViewModels.RelatoriosVM;

namespace SistemaGestaoTCC.Application.Queries.Relatorios.GetAll
{
    public class GetAllRelatorioQuery : IRequest<List<RelatorioViewModel>> { }
}
