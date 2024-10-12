using MediatR;
using SistemaGestaoTcc.Application.ViewModels.ProjetoEntregaVM;

namespace SistemaGestaoTcc.Application.Queries.ProjetoEntrega.GetAll
{
    public class GetAllProjetoEntregasQuery : IRequest<List<ProjetoEntregaViewModel>> { }
}
