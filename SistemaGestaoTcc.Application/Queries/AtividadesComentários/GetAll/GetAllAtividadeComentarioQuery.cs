using MediatR;
using SistemaGestaoTcc.Application.ViewModels.AtividadesComentarioVM;

namespace SistemaGestaoTcc.Application.Queries.AtividadesComentários.GetAll
{
    public class GetAllAtividadeComentarioQuery : IRequest<List<AtividadeComentarioViewModel>> { }
}
