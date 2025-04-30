using MediatR;
using SistemaGestaoTCC.Application.ViewModels.PropostasVM;

namespace SistemaGestaoTCC.Application.Queries.Propostas.GetAll
{
    public class GetAllPropostasQuery : IRequest<List<PropostaViewModel>>{ }
}
