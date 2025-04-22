using MediatR;
using SistemaGestaoTCC.Application.ViewModels.AnotacaoVM;

namespace SistemaGestaoTCC.Application.Queries.Anotacoes.GetAll
{
    public class GetAllAnotacoesQuery : IRequest<List<AnotacaoViewModel>> { }
}
