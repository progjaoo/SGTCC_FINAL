using MediatR;
using SistemaGestaoTcc.Application.ViewModels.ProjetoAtividadeVM;

namespace SistemaGestaoTcc.Application.Queries.ProjetoAtividades.GetAllAsync
{
    public class GetAllAtividadesQuery : IRequest<List<ProjetoAtividadeViewModel>> { }
}