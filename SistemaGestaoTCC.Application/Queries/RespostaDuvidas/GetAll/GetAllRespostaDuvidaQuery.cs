using MediatR;
using SistemaGestaoTCC.Application.ViewModels.DuvidasVM;

namespace SistemaGestaoTCC.Application.Queries.RespostaDuvidas.GetAll
{
    public class GetAllRespostaDuvidaQuery : IRequest<List<RespostaDuvidaViewModel>> { }

}
