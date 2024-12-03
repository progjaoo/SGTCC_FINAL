using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AtividadesComentarioVM;

namespace SistemaGestaoTCC.Application.Queries.AtividadesComentários.GetAll
{
    public class GetAllAtividadeComentarioQuery : IRequest<List<AtividadeComentarioViewModel>> { }
}
