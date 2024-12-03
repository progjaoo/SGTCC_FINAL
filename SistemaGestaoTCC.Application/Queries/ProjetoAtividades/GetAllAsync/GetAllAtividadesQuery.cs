using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoAtividadeVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoAtividades.GetAllAsync
{
    public class GetAllAtividadesQuery : IRequest<List<ProjetoAtividadeViewModel>> { }
}