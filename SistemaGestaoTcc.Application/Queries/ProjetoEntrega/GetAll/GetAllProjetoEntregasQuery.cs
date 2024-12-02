using MediatR;
using SistemaGestaoTCC.Application.ViewModels.ProjetoEntregaVM;

namespace SistemaGestaoTCC.Application.Queries.ProjetoEntrega.GetAll
{
    public class GetAllProjetoEntregasQuery : IRequest<List<ProjetoEntregaViewModel>> { }
}
